using HomeWebServer.Entities;
using HomeWebServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeWebServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceRepository _repository;

        public DevicesController(IDeviceRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetByIdAsync(Guid id)
        {
            var device = await _repository.GetByIdAsync(id);
            if (device == null)
            {
                return NotFound();
            }
            return device;
        }

        [HttpPost]
        public async Task<ActionResult<Device>> AddAsync(Device device)
        {
            await _repository.AddAsync(device);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = device.ID }, device);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, Device device)
        {
            if (id != device.ID)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync(device);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
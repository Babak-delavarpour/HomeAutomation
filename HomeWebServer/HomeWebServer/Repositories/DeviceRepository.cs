using HomeWebServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeWebServer.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly HomeDbContext _context;

        public DeviceRepository(HomeDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task<Device> GetByIdAsync(Guid id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task AddAsync(Device device)
        {
            _context.Devices.Add(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Entry(device).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var device = await _context.Devices.FindAsync(id);
            if (device != null)
            {
                _context.Devices.Remove(device);
                await _context.SaveChangesAsync();
            }
        }
    }
}
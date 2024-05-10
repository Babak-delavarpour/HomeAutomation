using HomeWebServer.Entities;

namespace HomeWebServer.Repositories
{
    public interface IDeviceRepository
    {
        Task<IEnumerable<Device>> GetAllAsync();
        Task<Device> GetByIdAsync(Guid id);
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(Guid id);
    }
}
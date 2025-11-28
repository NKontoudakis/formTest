using FormTest.DataAccess.Models;

namespace FormTest.Services.Interfaces
{
    public interface IApplicationFormService
    {
        // Read
        Task<ApplicationForm?> GetByIdAsync(int id);
        Task<List<ApplicationForm>> GetAllAsync(int pageNumber, int pageSize);

        // Create
        Task CreateAsync(ApplicationForm form);

        // Update
        Task UpdateAsync(ApplicationForm form);
    }
}

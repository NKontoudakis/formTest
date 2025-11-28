using System.Data.Common;
using System.Runtime.CompilerServices;
using FormTest.DataAccess;
using FormTest.DataAccess.Models;
using FormTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FormTest.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly AppDbContext _context;

        public ApplicationFormService(AppDbContext context)
        {
            _context = context;
        }

        async Task<ApplicationForm?> IApplicationFormService.GetByIdAsync(int id)
        {
            return await _context.ApplicationForms.FindAsync(id);
        }

        async Task<List<ApplicationForm>> IApplicationFormService.GetAllAsync(
            int pageNumber,
            int pageSize
        )
        {
            return await _context
                .ApplicationForms.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task CreateAsync(ApplicationForm form)
        {
            _context.ApplicationForms.Add(form);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ApplicationForm form)
        {
            _context.ApplicationForms.Update(form);
            await _context.SaveChangesAsync();
        }
    }
}

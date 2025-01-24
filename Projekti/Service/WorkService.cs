using Projekti.Data;
using Projekti.Models;
using Microsoft.EntityFrameworkCore; 

namespace Projekti.Service
{
    public class WorkService
    {
        private readonly MuseumDbContext _context;

        public WorkService(MuseumDbContext context)
        {
            _context = context;
        }

        // Get all works
        public async Task<List<Work>> GetAllWorksAsync()
        {
            return await _context.Works.ToListAsync();
        }

        // Add a new work
        public async Task AddWorkAsync(Work work)
        {
            _context.Works.Add(work);
            await _context.SaveChangesAsync();
        }

        // Update a work
        public async Task UpdateWorkAsync(Work work)
        {
            _context.Works.Update(work);
            await _context.SaveChangesAsync();
        }

        // Delete a work
        public async Task DeleteWorkAsync(int id)
        {
            var work = await _context.Works.FindAsync(id);
            if (work != null)
            {
                _context.Works.Remove(work);
                await _context.SaveChangesAsync();
            }
        }
    }
}


using ApplicationsApi.Data;
using ApplicationsApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsApi.Services
{
    public class ApplicationService:IApplication
    {
        private readonly ApplicationDbContext _context;
        public ApplicationService( ApplicationDbContext context) { 
            _context = context;
        }

        public async Task<IdentityResult> DeleteApplication(int id)
        {
            try
            {
                _context.Remove<Application>(await GetApplicationById(id));
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Application> GetApplicationById(int id)
        {
            try
            {
                return await _context.Applications.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<List<Application>> GetApplications()
        {
            try
            {
                return await _context.Applications.ToListAsync();
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Application> PostApplication(Application application)
        {
            try
            {
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();
                return await _context.Applications.LastAsync();
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }

        public async Task<Application> PutApplication(int id, Application application)
        {
            try
            {
                _context.Update<Application>(application);
                await _context.SaveChangesAsync();
                return await _context.Applications.LastAsync(a=>a.Id==id);
            }
            catch(Exception ex)
            {
                throw new NotImplementedException(ex.Message);
            }
        }
    }
}

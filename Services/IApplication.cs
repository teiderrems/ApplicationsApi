using ApplicationsApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ApplicationsApi.Services
{
    public interface IApplication
    {
        public Task<List<Application>> GetApplications();
        public Task<Application> GetApplicationById(int id);

        public Task<Application> PostApplication(Application application);

        public Task<Application> PutApplication(int id,Application application);

        public Task<IdentityResult> DeleteApplication(int id);
    }
}

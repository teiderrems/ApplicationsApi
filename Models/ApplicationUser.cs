using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace ApplicationsApi.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName {  get; set; }
        public string? LastName { get; set;}

        public string? Address {  get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Updated Date")]
        public DateTime? UpdatedAt { get; set; }


        public List<Application>? Applications { get; set; } = [];
    }
}

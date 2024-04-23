using System.ComponentModel.DataAnnotations;

namespace ApplicationsApi.Models
{
    public class Application:CommunProperty
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? JobDescription {  get; set; }

        public string? Address { get; set;}

        public String? Status { get; set; }="PENDING";

        public ApplicationUser? Orner { get; set; }
    }
}

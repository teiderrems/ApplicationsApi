using System.ComponentModel;

namespace ApplicationsApi.Models
{
    public class CommunProperty
    { 
        public int Id { get; set; }

        [DisplayName("Created Date")]
        public DateTime? CreatedAt { get; set; }

        [DisplayName("Updated Date")]
        public DateTime? UpdatedAt { get; set; }
    }
}

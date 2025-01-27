using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    // Platform class with properties Id, Name, Publisher, and cost 
    // microservice will manage assets for a platform
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Publisher { get; set; }        

        [Required]
        public string Cost { get; set; }
    }
}
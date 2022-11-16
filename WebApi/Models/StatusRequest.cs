using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class StatusRequest
    {
        [Required]
        public string Status { get; set; }
    }
}

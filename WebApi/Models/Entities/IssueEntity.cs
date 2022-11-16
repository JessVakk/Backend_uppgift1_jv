using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Entities
{
    public class IssueEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public StatusEntity Status { get; set; }
        public CustomerEntity Customer { get; set; }
        public ICollection<CommentEntity> Comments { get; set; }
    }
}

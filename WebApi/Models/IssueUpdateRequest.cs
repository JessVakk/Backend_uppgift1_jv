namespace WebApi.Models
{
    public class IssueUpdateRequest
    {
        public int Id { get; set; }

       
        public int StatusId { get; set; }
        public string Comment { get; set; }

     
    }
}

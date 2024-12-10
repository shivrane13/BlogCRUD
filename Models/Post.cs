using System.ComponentModel.DataAnnotations.Schema;

namespace BlogCRUD.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string summary { get; set; }
        public string body { get; set; }    
        public DateOnly date { get; set; }
        public int? authorId { get; set; }
        [ForeignKey("authorId")]
       public Authour? Authour { get; set; }
    }
}

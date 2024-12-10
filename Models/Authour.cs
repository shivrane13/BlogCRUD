namespace BlogCRUD.Models
{
    public class Authour
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email { get; set; }
        public List<Post>? Posts { get; set; }
    }
}

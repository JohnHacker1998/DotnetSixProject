
namespace firstproject.Entities{
    public class User{
        public int id{get;set;}
        public string? name{get;set;}

        public ICollection<Book>? books {get;set;}
    }
}
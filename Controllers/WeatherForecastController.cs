using Microsoft.AspNetCore.Mvc;
using firstproject.Data;
using firstproject.Entities;
using firstproject.Dtos;
namespace firstproject.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly DataContext _context;
 
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,DataContext context)
    {
        _logger = logger;
        _context=context;
    }

    [HttpPost(Name = "AddUser")]
    public async Task<ICollection<User>> AddUser(AddUserDto credentials)
    {
        User user=new User(); 
        user.id=credentials.id;
        user.name=credentials.name;
        Console.WriteLine(user);
        await _context.user.AddAsync(user);
        await _context.SaveChangesAsync();
        var UserList=new List<User>();
        UserList.Add(user);
        return UserList;
    }

    // [HttpPost(Name ="AddBook/{bookID}")]
    // public async Task<ActionResult<Book>> AddBook(AddBookDto credentials,[FromHeader]int bookID){
    //     var user=_context.user.Where(x=>x.id==bookID).ToList();
    //     if(user.Count==0) throw new KeyNotFoundException("Book isnot found!");
    //    Book book=new Book();
    //    book.id=credentials.id;
    //    book.name=credentials.name;
    //    book.user=user[0];
    //    await _context.book.AddAsync(book);
    //    await _context.SaveChangesAsync();
    //    return book;
    // }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication4.Models;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        private static string FilePath = "books.json";
        private readonly ILogger<HomeController> _logger;
        private static List<BookViewModel> _books = new List<BookViewModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Create() { 
        
            return View();
        }
        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (ModelState.IsValid) {
                _books = GetBooksFromFile();
                _books.Add(bookViewModel);
                SaveBooksToFile(_books);
                return View(nameof(Index));
            }
            
            return View();
        }
        public IActionResult List(string bookName)
        {
            var books =  GetBooksFromFile();
            if (!string.IsNullOrEmpty(bookName)) {
                books =  books.Where(x => x.Title.Contains(bookName)).ToList();
            }
            return View(books);
        }

        private List<BookViewModel> GetBooksFromFile() {
            if (System.IO.File.Exists(FilePath)) { 
                var json =  System.IO.File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<BookViewModel>>(json);
            }
            return new List<BookViewModel>();
        
        }
        private void SaveBooksToFile(List<BookViewModel> bookViewModels)
        {
            var json = JsonConvert.SerializeObject(bookViewModels, Formatting.Indented);
            System.IO.File.WriteAllText(FilePath, json);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

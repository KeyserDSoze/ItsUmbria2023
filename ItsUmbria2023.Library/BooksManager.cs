using ItsUmbria2023.Library.Models;
using System.Text.Json;

namespace ItsUmbria2023.Library
{
    internal class BooksManager
    {
        public string Name { get; }
        public BooksManager(string name)
        {
            Name = name;
        }
        public List<Book> GetBooks()
        {
            //integrazione con database e query
            var path = $@"C:\Users\AlessandroRapiti\source\repos\ItsUmbria2023\ItsUmbria2023\{Name}.json";
            var booksAsJson = File.ReadAllText(path);
            var books = !string.IsNullOrWhiteSpace(booksAsJson) ?
                        JsonSerializer.Deserialize<List<Book>>(booksAsJson)
                        : new List<Book>(); //read file and parse json
            return books;
        }
        public void SaveBooks(List<Book> books)
        {
            var path = $@"C:\Users\AlessandroRapiti\source\repos\ItsUmbria2023\ItsUmbria2023\{Name}.json";
            var json = JsonSerializer.Serialize(books);
            File.WriteAllText(path, json);
        }
    }
}

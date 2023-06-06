//Creare un'applicazione per una biblioteca che gestisce due tipologie di libro,
//romanzo e non romanzo, il libro potrà essere dato in prestito o essere disponibile
//in biblioteca.
//Dobbiamo salvare lo stato tramite json su un file e recuperare lo stato di tutti
//i libri inseriti nel momento dello startup.
//I dati dei libri romanzo e dei non romanzo devono essere salvati su due file diversi.


//system: Vuoi inserire un libro? O dare in prestito un libro?
//system: O dammi i libri presi in prestito da una persona.
//user: Inserire
//system: Inserisci titolo e autore
//user: Titolo e autore
//system: È un romanzo?
//user: Si
//system: Libro inserito, hai in catalogo X romanzi
//system: Vuoi inserire un libro? O dare in prestito un libro?
//user: Dare in prestito
//system: A chi?
//user: Maurizio
//system: Quale libro? Inserisci titolo del libro.
//user: Titolo
//system: Romanzo trovato e dato in prestito a Maurizio.


using ItsUmbria2023.Library;
using ItsUmbria2023.Library.Models;

var booksManagerForNovel = new BooksManager("novel");
var booksManagerForNotNovel = new BooksManager("not-novel");
var booksManagerForHorror = new BooksManager("horror");

var novelList = booksManagerForNovel.GetBooks();
var notNovelList = booksManagerForNotNovel.GetBooks();
var horrorList = booksManagerForHorror.GetBooks();

Console.WriteLine("Vuoi inserire un nuovo libro (1)? O dare in prestito un libro (2)? O uscire (3)?");
var response = Console.ReadLine();
while (response != "3")
{
    if (response == "1")
    {
        Console.WriteLine("Inserisci titolo e autore");
        var title = Console.ReadLine();
        var author = Console.ReadLine();
        Console.WriteLine("È un romanzo? y/n");
        bool isNovel = Console.ReadLine() == "y";
        var book = new Book
        {
            Id = Guid.NewGuid().ToString(),
            Title = title,
            Author = author,
            IsNovel = isNovel,
        };
        if (isNovel)
        {
            novelList.Add(book);
            booksManagerForNovel.SaveBooks(novelList);
            Console.WriteLine($"Hai inserito {book.Title} di {book.Author}. Hai {novelList.Count} romanzi.");
        }
        else
        {
            notNovelList.Add(book);
            booksManagerForNotNovel.SaveBooks(notNovelList);
            Console.WriteLine($"Hai inserito {book.Title} di {book.Author}. Hai {notNovelList.Count} non romanzi.");
        }
    }
    else if (response == "2")
    {
        Console.WriteLine("A chi?");
        var owner = Console.ReadLine();
        Console.WriteLine("Quale libro? Inserisci il titolo.");
        var title = Console.ReadLine();


        var book = novelList.FirstOrDefault(x => x.Title == title);
        //var bookWithOwner = novelList.FirstOrDefault(x => x.Owner == "dasd");
        //var newBookSearch = novelList.FirstOrDefault2(x => x.Title == title);
        //var books = novelList.Where(book => book.Owner?.Contains("Alessandro") == true);
        if (book == null)
        {
            book = notNovelList.FirstOrDefault(x => x.Title == title);
        }

        if (book == null)
        {
            Console.WriteLine("Non ci sono libri con questo nome");
        }
        else if (book.Owner != null)
        {
            Console.WriteLine($"Il libro è già in prestito a {book.Owner}");
        }
        else
        {
            book.Owner = owner;
            if (book.IsNovel)
            {
                booksManagerForNovel.SaveBooks(novelList);
            }
            else
            {
                booksManagerForNotNovel.SaveBooks(notNovelList);
            }
            Console.WriteLine($"Hai dato in prestito {book.Title} di {book.Author} a {book.Owner}");
        }
    }
}
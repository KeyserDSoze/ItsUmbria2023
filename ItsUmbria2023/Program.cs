using ItsUmbria2023.Models;
using System.Text.Json;

Console.WriteLine("Vuoi inserire una nuova carta d'identità? y/n");
var response = Console.ReadLine();
var path = @"C:\Users\AlessandroRapiti\source\repos\ItsUmbria2023\ItsUmbria2023\identities.json";
var cardListAsJson = File.ReadAllText(path);
var cardList = !string.IsNullOrWhiteSpace(cardListAsJson) ?
    JsonSerializer.Deserialize<List<IdentityCard>>(cardListAsJson)
    : new List<IdentityCard>(); //read file and parse json

while (response == "y")
{
    #region inserimento carta identità
    Console.WriteLine("Inserisci nome, cognome, data di nascita");
    Console.WriteLine("Inserisci il nome");
    var firstName = Console.ReadLine();
    Console.WriteLine("Inserisci il cognome");
    var lastName = Console.ReadLine();
    Console.WriteLine("Inserisci la data di nascita");
    var date = Console.ReadLine();
    var card = new IdentityCard()
    {
        Id = Guid.NewGuid().ToString(),
        FirstName = firstName,
        LastName = lastName,
        BirthDate = date
    };
    #endregion
    cardList.Add(card);
    var cardListSerialized = JsonSerializer.Serialize(cardList);
    //serialize and save on file
    File.WriteAllText(path, cardListSerialized);
    Console.WriteLine($"Hai inserito {card.FirstName} {card.LastName} {card.BirthDate}.");
    Console.WriteLine($"Sono state inserite {cardList.Count} carte d'identità.");

    Console.WriteLine("Vuoi inserire una nuova carta d'identità? y/n");
    response = Console.ReadLine();
}
//var streamWriter = new StreamWriter(@"C:\dadsadsadas.json");
//streamWriter.Write(json);

//var streamReader = new StreamReader(@"C:\dadsadsadas.json");
//var json = streamReader.ReadToEnd();

//stack example
//int x = 0;
//int y = 0;
//int sum = x + y;
//Console.WriteLine(sum);
//return sum;

//allocazione memoria int
//assegnazione 0
//allocazione memoria int
//assegnazione 0
//allocazione memoria int
//somma x e y
//assegnazione somma



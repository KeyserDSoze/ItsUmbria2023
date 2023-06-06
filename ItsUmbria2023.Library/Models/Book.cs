namespace ItsUmbria2023.Library.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsNovel { get; set; }
        public string? Owner { get; set; } //persona che ha preso in prestito
    }
}

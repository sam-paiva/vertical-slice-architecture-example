namespace LibraryAPI.Domain;

public class Book
{
    public Book(string name, string authorName, decimal price)
    {
        Id = Guid.NewGuid();
        Name = name ?? throw new ArgumentNullException(nameof(name));
        AuthorName = authorName ?? throw new ArgumentNullException(nameof(authorName));
        Price = price;
        RegisterDate = DateTime.Now;
    }
    
    public Guid Id { get; }
    public string Name { get; private set; }
    public DateTime RegisterDate { get; private set; }
    public decimal Price { get; private set; }
    public string AuthorName { get; private set; }
}
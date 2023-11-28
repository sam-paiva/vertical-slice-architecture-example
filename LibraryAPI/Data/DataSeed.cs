using LibraryAPI.Domain;

namespace LibraryAPI.Data;

public static class DataSeed
{
    public static void Seed(DataContext context)
    {
        context.Books?.Add(new Book("Domain-Driven Design: Tackling Complexity in the Heart of Software", "Eric Evans",
            32.72M));
        
        context.Books?.Add(new Book("Implementing Domain-Driven Design", "Vaugh Vernon",
            44.02M));
        
        context.Books?.Add(new Book("The C# Player's Guide",
            "RB Whitaker",
            26.43M));

        context.SaveChanges();
    }
}
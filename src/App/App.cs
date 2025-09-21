using Microsoft.EntityFrameworkCore;

namespace App;

public class AppActions
{
    private readonly AppDbContext _context;

    public AppActions(AppDbContext context)
    {
        _context = context;
        _context.Database.Migrate();
    }

    public void AddOne() =>
        _context.Add(new Person { Name = "Alice", Age = 25 });

    public void AddMany()
    {
        _context.AddRange(
            new Person { Name = "Bob", Age = 30 },
            new Person { Name = "Charlie", Age = 35 }
        );
    }

    public void UpdateOne()
    {
        var person = _context.Persons.FirstOrDefault();
        if (person != null) person.Age = 99;
    }

    public void UpdateMany()
    {
        foreach (var p in _context.Persons.Where(p => p.Age > 20))
            p.Age += 1;
    }

    public void DeleteOne()
    {
        var person = _context.Persons.FirstOrDefault();
        if (person != null) _context.Remove(person);
    }

    public void DeleteMany()
    {
        var toDelete = _context.Persons.Where(p => p.Age < 30).ToList();
        _context.RemoveRange(toDelete);
    }

    public int CountRecords() => _context.Persons.Count();

    public Person? GetOneByCondition() =>
        _context.Persons.FirstOrDefault(p => p.Name == "Alice");

    public List<Person> GetManyByCondition() =>
        _context.Persons.Where(p => p.Age >= 30).ToList();

    public void Save() => _context.SaveChanges();
}

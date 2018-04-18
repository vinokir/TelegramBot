using System.Data.Entity;

namespace LoymaxTestTask.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
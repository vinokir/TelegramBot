using System;
using System.Data.Entity;

namespace LoymaxTestTask.Models
{
    public class PersonDbInitializer : DropCreateDatabaseAlways<PersonContext>
    {
        protected override void Seed(PersonContext db)
        {
            db.Persons.Add(new Person { Surname = "Иванов", Name = "Иван", Patronymic = "Иванович", Birthday = new DateTime(1956, 11, 26),chatId = 1L });
            

            base.Seed(db);
        }
    }
}
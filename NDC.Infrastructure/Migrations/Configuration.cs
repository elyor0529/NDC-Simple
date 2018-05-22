namespace NDC.Infrastructure.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NDC.Infrastructure.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.People.AddOrUpdate(p => p.Id,
              new Person { Gender = "Male", Id = 1, FullName = "John White", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 2, FullName = "Natalie Black", BirthDate = DateTime.Now.AddYears(-38), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 3, FullName = "Simon Yellow", BirthDate = DateTime.Now.AddYears(-18), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 4, FullName = "Jessica Red", BirthDate = DateTime.Now.AddYears(-68), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 5, FullName = "Monika Brown", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 6, FullName = "Joshua Aquamarine", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 7, FullName = "Jim Blue", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 8, FullName = "Angela Green", BirthDate = DateTime.Now.AddYears(-78), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 9, FullName = "Dorian Gray", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 10, FullName = "Marina Violet", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 11, FullName = "Modesty Gold", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 12, FullName = "Markos Navy", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 13, FullName = "Alanah White", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Male", Id = 14, FullName = "John Smith", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 },
              new Person { Gender = "Female", Id = 15, FullName = "Elena Barget", BirthDate = DateTime.Now.AddYears(-28), Country = "USA", Height = 170, Weight = 80 }
            );

        }
    }
}

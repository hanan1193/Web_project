using Microsoft.EntityFrameworkCore;

namespace project3.Models
{
    public class DatasiteContext:DbContext
    {

        public DatasiteContext(DbContextOptions<DatasiteContext> options)

            : base(options)

        { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Car> Cars { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "Ahmad",
                    Password = 123456,
                    Email = "Ahmad@gmail.com"
                },
                new User
                {
                    UserId = 2,
                    Name = "Lujain",
                    Password = 123456,
                    Email = "Lujain@gmail.com"
                },
                new User
                {
                    UserId = 3,
                    Name = "Mahmood",
                    Password = 123456,
                    Email = "Mahmood@gmail.com"
                });
            modelBuilder.Entity<Car>().HasData(
           new Car
           {
               CarId = 1,
               Type = "Ford",
               Model = 2011,
               Color = "Black",
               Price = 200000,
               UserId=1
           },
           new Car
           {
               CarId = 2,
               Type = "BMW",
               Model = 2019,
               Color = "Red",
               Price = 100000,
               UserId=2
           },
           new Car
           {
               CarId = 3,
               Type = "Scoda",
               Model = 2013,
               Color = "White",
               Price = 150000,
               UserId=1
           }

       );
        }
    }
}

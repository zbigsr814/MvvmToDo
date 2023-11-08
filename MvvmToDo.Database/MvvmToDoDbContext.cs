using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToDo.Database
{
    public class MvvmToDoDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            string dbFilePath = Path.Combine(Environment.CurrentDirectory, "newDB.sqlite");
            string connectionString = $"Data Source={dbFilePath};";

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}

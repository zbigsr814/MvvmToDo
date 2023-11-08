using MvvmToDo.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToDo.Core.Helpers
{
    public class DatabaseLocator
    {
        public static MvvmToDoDbContext Database { get; set; } = new MvvmToDoDbContext();
    }
}

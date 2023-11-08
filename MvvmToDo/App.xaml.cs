using MvvmToDo.Core.Helpers;
using MvvmToDo.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmToDo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var database = new MvvmToDoDbContext();
            database.Database.EnsureCreated();
            DatabaseLocator.Database = database;
        }
    }
}

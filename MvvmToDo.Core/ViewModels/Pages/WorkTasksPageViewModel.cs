using MvvmToDo.Core.Helpers;
using MvvmToDo.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmToDo.Core
{
    public class WorkTasksPageViewModel : BaseViewModel
    {
        public ObservableCollection<WorkTaskViewModel> WorkTaskList { get; set; } = new ObservableCollection<WorkTaskViewModel>();
        public string NewWorkTaskTitle { get; set; }
        public string NewWorkTaskDescription { get; set; }

        public string extNewWorkTaskTitle
        {
            get { return NewWorkTaskTitle; }
            set
            {
                NewWorkTaskTitle = value;
                OnPropertyChanged(NewWorkTaskTitle);
            }
        }
        public string extNewWorkTaskDescription
        {
            get { return NewWorkTaskDescription; }
            set
            {
                NewWorkTaskDescription = value;
                OnPropertyChanged(NewWorkTaskDescription);
            }
        }
        public ICommand AddNewTaskCommand { get; set; }
        public ICommand DeleteTasksCommand { get; set; }

        public WorkTasksPageViewModel()
        {
            AddNewTaskCommand = new RelayComand(AddNewWorkTaskToList);
            DeleteTasksCommand = new RelayComand(DeleteTasks);

            foreach ( var item in DatabaseLocator.Database.WorkTasks.ToList())  // przypisywanie zmiennych z DB do VM
            {
                WorkTaskList.Add(new WorkTaskViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    CreatedDate = item.CreatedDate
                });
            }
        }

        private void DeleteTasks()
        {
            for (int i = 0; i < WorkTaskList.Count; i++)
            {
                if (WorkTaskList[i].IsSelected) 
                {
                    var foundEntity = DatabaseLocator.Database.WorkTasks.FirstOrDefault(x => x.Id == WorkTaskList[i].Id);
                    if (foundEntity != null)
                    {
                        DatabaseLocator.Database.WorkTasks.Remove(foundEntity);
                    }                                                                   // usuwanie z DB

                    WorkTaskList.RemoveAt(i);
                    i--;
                }
            }
            DatabaseLocator.Database.SaveChanges();
        }

        public void AddNewWorkTaskToList()
        {
            DatabaseLocator.Database.Add(new WorkTask()
            {
                Title = NewWorkTaskTitle,
                Description =  NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            });
            DatabaseLocator.Database.SaveChanges();

            var newTask = new WorkTaskViewModel()
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreatedDate = DateTime.Now
            };
            WorkTaskList.Add(newTask);

            extNewWorkTaskTitle = string.Empty;
            extNewWorkTaskDescription = string.Empty;
        }
    }
}

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
        }

        private void DeleteTasks()
        {
            //ObservableCollection<WorkTaskViewModel> tmpList = WorkTaskList;
            for (int i = 0; i < WorkTaskList.Count; i++)
            {
                if (WorkTaskList[i].IsSelected) 
                { 
                    WorkTaskList.RemoveAt(i);
                    i--;
                }
            }
        }

        public void AddNewWorkTaskToList()
        {
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

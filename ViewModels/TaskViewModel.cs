using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZarzadzanieZadaniamiDnia.Models;
using ZarzadzanieZadaniamiDnia.Json;

namespace ZarzadzanieZadaniamiDnia.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<SingleTask> tasks = new ObservableCollection<SingleTask>();

       
        public ObservableCollection<SingleTask> Tasks2 = new ObservableCollection<SingleTask>();

        [ObservableProperty]
        private string newNameTask, newPriorityTask;

        public TaskViewModel()
        {
            LoadTaskAsync();
            Tasks2 = Tasks;
        }

        [RelayCommand]
        public async void AddTask()
        {
            Tasks.Add(new SingleTask { Name = NewNameTask, Priority = NewPriorityTask, IsCompleted = false });
            NewNameTask = string.Empty;
            NewPriorityTask = string.Empty;
            await SaveTasksAsync();
        }

        [RelayCommand]
        public async void RemoveTask(SingleTask task)
        {
            if(Tasks.Contains(task))
            {
                Tasks.Remove(task);
                await SaveTasksAsync();
            }
        }

        [RelayCommand]
        public async void EditTask(SingleTask task)
        {
            var taskToEdit = Tasks.FirstOrDefault(t => t == task);
            if(taskToEdit != null)
            {
                taskToEdit.Name = NewNameTask;
                taskToEdit.Priority = NewPriorityTask;
                NewNameTask = string.Empty;
                NewPriorityTask = string.Empty;
                await SaveTasksAsync();
            }
        }

        [RelayCommand]
        public void SortByPriority()
        {
            var sortedTasks = Tasks.OrderByDescending(t => t.Priority).ToList();
            Tasks = new ObservableCollection<SingleTask>(sortedTasks);
        }

        [RelayCommand]
        public void SortByStatus()
        {
            var sortedTasks = Tasks.OrderBy(t => t.IsCompleted).ToList();
            Tasks = new ObservableCollection<SingleTask>(sortedTasks);
        }

        [RelayCommand]
        public async void FilterTasks(bool showCompleted)
        {
            Tasks2 = await DeSSerializacja.LoadTasksAsync();
            if (showCompleted)
            {
                Tasks = new ObservableCollection<SingleTask>(Tasks2.Where(t => t.IsCompleted));
            }
            else
            {
                Tasks = new ObservableCollection<SingleTask>(Tasks2.Where(t => !t.IsCompleted));
            }
        }

        //[RelayCommand]
        //public void FilterCompletedTasks(bool showCompleted)
        //{
        //    Tasks2 = await DeSSerializacja.LoadTasksAsync();
        //    if (showCompleted)
        //    {
        //        Tasks = new ObservableCollection<SingleTask>(Tasks2.Where(t => t.IsCompleted));
        //    }
        //    else
        //    {
        //        Tasks = new ObservableCollection<SingleTask>(Tasks2.Where(t => !t.IsCompleted));
        //    }
        //}


        public async Task SaveTasksAsync()
        {
            await DeSSerializacja.SaveTasksAsync(Tasks);
        }

        public async Task LoadTaskAsync()
        {
            Tasks = await DeSSerializacja.LoadTasksAsync();
        }



    }
}

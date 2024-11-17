using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ZarzadzanieZadaniamiDnia.Json;
using ZarzadzanieZadaniamiDnia.Models;

namespace ZarzadzanieZadaniamiDnia.ViewModels
{
    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<SingleTask> displayedTasks = new ObservableCollection<SingleTask>();

        public ObservableCollection<SingleTask> TasksFromFile = new ObservableCollection<SingleTask>();

        [ObservableProperty]
        private string newNameTask, newPriorityTask;

        public TaskViewModel()
        {
            DisplayedTasks = DeSSerializacja.LoadTasks();

            if (DisplayedTasks.Count == 0)
                MockupTasks();

            TasksFromFile = DisplayedTasks;
        }

        [RelayCommand]
        public async void AddTask()
        {
            DisplayedTasks.Add(
            new SingleTask
            {
                Name = NewNameTask,
                Priority = NewPriorityTask,
                IsCompleted = false
            });

            NewNameTask = string.Empty;

            NewPriorityTask = string.Empty;

            await DeSSerializacja.SaveTasksAsync(DisplayedTasks);
        }

        [RelayCommand]
        public async void RemoveTask(SingleTask task)
        {
            if (DisplayedTasks.Contains(task))
            {
                DisplayedTasks.Remove(task);

                await DeSSerializacja.SaveTasksAsync(DisplayedTasks);
            }
        }

        [RelayCommand]
        public async void EditTask(SingleTask task)
        {
            var taskToEdit = DisplayedTasks.FirstOrDefault(t => t == task);
            if (taskToEdit != null)
            {
                taskToEdit.Name = NewNameTask;
                taskToEdit.Priority = NewPriorityTask;
                NewNameTask = string.Empty;
                NewPriorityTask = string.Empty;

                await DeSSerializacja.SaveTasksAsync(DisplayedTasks);
            }
        }

        [RelayCommand]
        public void SortByPriority()
        {
            DisplayedTasks = TasksFromFile.OrderBy(t => t.Priority)
                                           .ToList()
                                           .ToObservableCollection();
        }

        [RelayCommand]
        public void SortByStatus()
        {
            DisplayedTasks = TasksFromFile.OrderBy(t => t.IsCompleted)
                                           .ToList()
                                           .ToObservableCollection();
        }

        [RelayCommand]
        public async void FilterTasks(bool showCompleted)
        {
            TasksFromFile = await DeSSerializacja.LoadTasksAsync();

            DisplayedTasks = TasksFromFile.Where(t => t.IsCompleted == showCompleted)
                                          .ToList()
                                          .ToObservableCollection();
                                          
            //if (showCompleted)
            //{
            //    DisplayedTasks = new ObservableCollection<SingleTask>(TasksFromFile.Where(t => t.IsCompleted));
            //}
            //else
            //{
            //    DisplayedTasks = new ObservableCollection<SingleTask>(TasksFromFile.Where(t => !t.IsCompleted));
            //}
        }

        //public async Task SaveTasksAsync()
        //{
        //    await DeSSerializacja.SaveTasksAsync(Tasks);
        //}

        //public async Task LoadTaskAsync()
        //{
        //    Tasks = await DeSSerializacja.LoadTasksAsync();
        //}

        private void MockupTasks()
        {
            DisplayedTasks = new ObservableCollection<SingleTask>()
            {
                new SingleTask()
                {
                    Name = "Zadanie1",
                    Priority = "1",
                    IsCompleted = true,
                },
                new SingleTask()
                {
                    Name = "Zadanie2",
                    Priority = "2",
                    IsCompleted = true,
                },
                new SingleTask()
                {
                    Name = "Zadanie3",
                    Priority = "3",
                    IsCompleted = false,
                },
            };
        }

    }
}
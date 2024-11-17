//using AndroidX.Lifecycle;
using System.Collections.ObjectModel;
using ZarzadzanieZadaniamiDnia.Json;
using ZarzadzanieZadaniamiDnia.Models;
using ZarzadzanieZadaniamiDnia.ViewModels;
namespace ZarzadzanieZadaniamiDnia
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnFilterToggled(object sender, ToggledEventArgs e)
        {
            var isToggled = e.Value; 
            var viewModel = BindingContext as TaskViewModel;
            if (viewModel != null)
            {
                viewModel.FilterTasks(isToggled);
            }
        }

        private async void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var viewModel = BindingContext as TaskViewModel;
            if (viewModel != null)
            {
                await DeSSerializacja.SaveTasksAsync(viewModel.TasksFromFile);
            }
        }

        
    }

}

//using AndroidX.Lifecycle;
using ZarzadzanieZadaniamiDnia.ViewModels;
using ZarzadzanieZadaniamiDnia.Json;
namespace ZarzadzanieZadaniamiDnia
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

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
                await viewModel.SaveTasksAsync();
            }
        }

        
    }

}

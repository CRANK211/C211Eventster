using Windows.UI.Xaml;
using C211Eventster.ViewModels;
using Windows.UI.Xaml.Controls;

namespace C211Eventster.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
            this.Loaded += (sender, args) => SearchTextBox.Focus(FocusState.Keyboard);
        }

        // strongly-typed view models enable x:bind
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;
    }
}

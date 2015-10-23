using Windows.Foundation;
using C211Eventster.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using C211Eventster.Library.Models;

namespace C211Eventster.Views
{
    public sealed partial class DetailPage : Page
    {
        public DetailPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public DetailPageViewModel ViewModel => DataContext as DetailPageViewModel;

        private void SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SearchResults.SelectedItem != null)
            {
                var eventsterEvent = SearchResults.SelectedItem as EventsterEvent;
                if (eventsterEvent != null)
                {
                    DetailMapControl.MapElements.Clear();
                    var mi = new MapIcon
                    {
                        Location = eventsterEvent.Location,
                        NormalizedAnchorPoint = new Point(0.5, 1.0),
                        Title = eventsterEvent.Venue,
                        ZIndex = 0
                    };

                    DetailMapControl.MapElements.Add(mi);
                }
            }
        }

    }
}


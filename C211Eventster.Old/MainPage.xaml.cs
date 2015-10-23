using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using C211Eventster.Library.Models;
using C211Eventster.Library.Services;
using C211Eventster.Old.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace C211Eventster.Old
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += (sender, args) => ViewModel.ResultsViewModel.ResultsLoaded += ResultsViewModel_ResultsLoaded;
        }

        private void ResultsViewModel_ResultsLoaded(object sender, System.EventArgs e)
        {
            OverallMapControl.MapElements.Clear();
            var geopoints = new List<Geopoint>();

            foreach (var eventsterEvent in ViewModel.ResultsViewModel.EventsterEvents)
            {
                geopoints.Add(eventsterEvent.Location);
                var mi = new MapIcon
                {
                    Location = eventsterEvent.Location,
                    NormalizedAnchorPoint = new Point(0.5, 1.0),
                    Title = eventsterEvent.Venue,
                    ZIndex = 0
                };

                OverallMapControl.MapElements.Add(mi);
            }

            OverallMapControl.Center = MapHelper.GetCentralGeopoint(geopoints);
        }

        public MainPageViewModel ViewModel => DataContext as MainPageViewModel;

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
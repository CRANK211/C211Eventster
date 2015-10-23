using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using C211Eventster.Library.Models;
using C211Eventster.Library.Services;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace C211Eventster.Views
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NearMePage : Page
    {
        public NearMePage()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            OverallMapControl.MapElements.Clear();
            var geopoints = new List<Geopoint>();

            foreach (var eventsterEvent in EventsterEvent.EventFactory(10))
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

            var centralGeopoint = MapHelper.GetCentralGeopoint(geopoints);

            var centerIcon = new MapIcon
            {
                Location = centralGeopoint,
                NormalizedAnchorPoint = new Point(0.5, 1.0),
                Title = "YOU ARE HERE!",
                ZIndex = 0
            };

            OverallMapControl.MapElements.Add(centerIcon);


            OverallMapControl.Center = centralGeopoint;
        }
    }
}
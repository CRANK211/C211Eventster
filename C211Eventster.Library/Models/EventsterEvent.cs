using System;
using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace C211Eventster.Library.Models
{
    public class EventsterEvent : IEquatable<EventsterEvent>
    {
        private static readonly Random Random = new Random();

        private static readonly string[] EventNameFragment1 =
        {
            "Amazing",
            "Awesome",
            "Cool",
            "Mega",
            "Major"
        };

        private static readonly string[] EventNameFragment2 =
        {
            "Motorcycle Event",
            "Wrestling Match",
            "Hockey Match",
            "Monster Trucks",
            "Football Match",
            "Fighter Competition",
            "ComicCon"
        };

        private static readonly string[] EventNameFragment3 =
        {
            "Major Hall",
            "Super Rink",
            "Cokesi Arena",
            "Colorado Theater",
            "The Gallery"
        };

        private static readonly string[] AddressOptions =
        {
            "1330 27th St., Denver,CO 80205",
            "3263 South Broadway, Englewood, CO 80113",
            "2637 Welton Street,Denver, CO 80205",
            "1512 Curtis St.,Denver, CO 80202",
            "2344 East Iliff Avenue,Denver ,CO 80208",
            "100 W. 14th Ave. Pkwy., Denver ,CO 80204",
            "2510 E. Colfax Ave., Denver, CO 80206",
            "935 East Colfax Avenue, Denver, CO 80218",
            "3317 East Colfax Avenue, Denver, CO 80206",
            "2344 E. Iliff Ave.,Denver, CO 80208",
            "930 Lincoln St.,Denver, CO 80203"
        };

        private static readonly Geopoint[] AddressBasicGeopoints =
        {
            new Geopoint(new BasicGeoposition {Longitude = -104.98451001942158, Latitude = 39.759589964523911}),
            new Geopoint(new BasicGeoposition {Longitude = -104.98802186921239, Latitude = 39.657638529315591}),
            new Geopoint(new BasicGeoposition {Longitude = -104.978909986094, Latitude = 39.7544599883258}),
            new Geopoint(new BasicGeoposition {Longitude = -104.995440021157, Latitude = 39.7463199868798}),
            new Geopoint(new BasicGeoposition {Longitude = -104.959930423647, Latitude = 39.6745910961181}),
            new Geopoint(new BasicGeoposition {Longitude = -104.989519966766, Latitude = 39.7374700382352}),
            new Geopoint(new BasicGeoposition {Longitude = -104.956916794181, Latitude = 39.7399711981416}),
            new Geopoint(new BasicGeoposition {Longitude = -104.975260002539, Latitude = 39.7403900418431}),
            new Geopoint(new BasicGeoposition {Longitude = -104.948356607929, Latitude = 39.7403182927519}),
            new Geopoint(new BasicGeoposition {Longitude = -104.948356607929, Latitude = 39.7403182927519}),
            new Geopoint(new BasicGeoposition {Longitude = -104.948356607929, Latitude = 39.7403182927519}),
            new Geopoint(new BasicGeoposition {Longitude = -104.959930423647, Latitude = 39.6745910961181}),
            new Geopoint(new BasicGeoposition {Longitude = -104.985960004851, Latitude = 39.7309500072151})
        };

        public string Description { get; set; } =
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero. Sed cursus ante dapibus diam. Sed nisi. Nulla quis sem at nibh elementum imperdiet. Duis sagittis ipsum. Praesent mauris. "
            ;


        public string EventName { get; set; }

        public string Venue { get; set; }

        public string Address { get; set; }

        public Geopoint Location { get; set; }

        public BitmapImage ImageSource { get; set; }

        public Symbol Symbol { get; set; }

        public bool Equals(EventsterEvent other)
        {
            return EventName.Equals(other.EventName);
        }

        private static string GetEntry(string[] parts)
        {
            return parts[Random.Next(0, parts.Length - 1)];
        }

        public static List<EventsterEvent> EventFactory(int count)
        {
            var events = new List<EventsterEvent>();

            while (count > 0)
            {
                var eventsterEvent = new EventsterEvent
                {
                    EventName = $"{GetEntry(EventNameFragment1)} {GetEntry(EventNameFragment2)}",
                    Venue = $"{GetEntry(EventNameFragment3)}",
                    Address = GetEntry(AddressOptions),
                    ImageSource =
                        new BitmapImage(new Uri($"ms-appx:///Assets/EventImagesSmall/{Random.Next(1, 11)}.jpg"))
                };

                eventsterEvent.Symbol = new[] { Symbol.Favorite, Symbol.Emoji, Symbol.Memo, }[Random.Next(0,3)];
                eventsterEvent.Location =
                    AddressBasicGeopoints[Array.IndexOf(AddressOptions, eventsterEvent.Address)];
                if (events.Contains(eventsterEvent))
                {
                    continue;
                }

                events.Add(eventsterEvent);
                count--;
            }

            return events;
        }

        public override string ToString()
        {
            return EventName;
        }
    }
}
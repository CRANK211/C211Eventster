using System;
using System.Collections.ObjectModel;
using System.Linq;
using C211Eventster.Library.Models;
using Template10.Mvvm;

namespace C211Eventster.Library.ViewModels
{
    public class ResultsViewModel : ViewModelBase
    {
        private EventsterEvent _currentEvent;
        private ObservableCollection<EventsterEvent> _events = new ObservableCollection<EventsterEvent>();

        public ObservableCollection<EventsterEvent> EventsterEvents
        {
            get { return _events; }
            set { Set(ref _events, value); }
        }

        public EventsterEvent CurrentEvent
        {
            get { return _currentEvent; }
            set { Set(ref _currentEvent, value); }
        }

        public event EventHandler ResultsLoaded;

        protected virtual void OnResultsLoaded()
        {
            ResultsLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void LoadEvents()
        {
            EventsterEvents.Clear();
            EventsterEvent.EventFactory(20).ForEach(e => EventsterEvents.Add(e));
            this.CurrentEvent = EventsterEvents.First();
            OnResultsLoaded();
        }
    }
}
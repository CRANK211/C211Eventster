using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using C211Eventster.Library.ViewModels;

namespace C211Eventster.ViewModels
{
    public class DetailPageViewModel : C211Eventster.Mvvm.ViewModelBase
    {
        private ResultsViewModel _resultsResultsViewModel;
        private SearchViewModel _searchViewModel;

        public DetailPageViewModel()
        {
            ResultsViewModel = new ResultsViewModel();
            SearchViewModel = new SearchViewModel();
            if (!Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                SearchViewModel.SearchInitiated += SearchViewModel_SearchInitiated;
            }

        }

        public SearchViewModel SearchViewModel
        {
            get { return _searchViewModel; }
            set { Set(ref _searchViewModel, value); }
        }

        public ResultsViewModel ResultsViewModel
        {
            get { return _resultsResultsViewModel; }
            set { Set(ref _resultsResultsViewModel, value); }
        }

        private void SearchViewModel_SearchInitiated(SearchViewModel senderSearchViewModel, EventArgs e)
        {
            ResultsViewModel.LoadEvents();
        }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.Any())
            {
                // use cache value(s)
                if (state.ContainsKey(nameof(Value)))
                {
                    SearchViewModel.SearchString = state[nameof(SearchViewModel.SearchString)]?.ToString();
                }
                // clear any cache
                state.Clear();
            }
            else
            {
                // use navigation parameter
                SearchViewModel.SearchString = parameter?.ToString();
            }
            SearchViewModel.Search();
        }

        public override Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
            {
                // persist into cache
                state[nameof(SearchViewModel.SearchString)] = Value;
            }
            return base.OnNavigatedFromAsync(state, suspending);
        }

        public override void OnNavigatingFrom(NavigatingEventArgs args)
        {
            args.Cancel = false;
        }

        private string _Value = "Default";
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }
    }
}


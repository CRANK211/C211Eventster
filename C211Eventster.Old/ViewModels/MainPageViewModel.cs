using System;
using C211Eventster.Library.ViewModels;
using Template10.Mvvm;

namespace C211Eventster.Old.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ResultsViewModel _resultsResultsViewModel;
        private SearchViewModel _searchViewModel;

        public MainPageViewModel()
        {
            ResultsViewModel = new ResultsViewModel();
            SearchViewModel = new SearchViewModel();
            SearchViewModel.SearchInitiated += SearchViewModel_SearchInitiated;
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
    }
}
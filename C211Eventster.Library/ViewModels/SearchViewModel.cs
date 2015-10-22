using System;
using Template10.Mvvm;

namespace C211Eventster.Library.ViewModels
{
    public delegate void SearchInitiatedHandler(SearchViewModel senderSearchViewModel, EventArgs e);

    public class SearchViewModel : ViewModelBase
    {
        private string _searchString;

        public string SearchString
        {
            get { return _searchString; }
            set { Set(ref _searchString, value); }
        }

        public event SearchInitiatedHandler SearchInitiated;

        protected virtual void OnSearchInitiated()
        {
            SearchInitiated?.Invoke(this, EventArgs.Empty);
        }

        public void Search()
        {
            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                OnSearchInitiated();
            }
        }
    }
}
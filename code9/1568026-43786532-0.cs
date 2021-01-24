            foreach(var x in _navigation.Navigation.NavigationStack.ToList())
            {
              if((x.GetType() == typeof(/* name of your scanner page */)))
              {
                _navigation.Navigation.RemovePage(x);
              }
            }
            var page = new /* your scanner page */();
            _navigation.PushAsync( /* your scanner page */);

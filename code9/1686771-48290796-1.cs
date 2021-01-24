    public IList<CardDataModel> CardDataCollection { get; set; }
        public ICommand SelectedItem;
        public CardDataViewModel()
        {
            CardDataCollection = new List<CardDataModel>();
            GenerateCardModel();
            SelectedItem = new Command<CardDataModel>(NavigateToCardPage)
        }
        private async void NavigateToCardPage(CardDataModel c)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CardPage(c));
        }
        private void GenerateCardModel()
        {
            // for (var i = 0; i < 10; i++)
            {
                CardDataCollection = new ObservableCollection<CardDataModel>
                {
                    new CardDataModel(typeof(FindArtistsPage))
                    {
                         HeadLines ="Find Artists Near You" ,
                         ProfileImage = "Person_7.jpg",
                         HeadLinesDesc = "Find Pefromers Near your location",
                         // Code to go another page should go here
                    },
                };
            }
        }
    }

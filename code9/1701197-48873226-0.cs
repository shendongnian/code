    Cards = new ObservableCollection<Card>(LoadCards());
            FilteredCards = new ObservableCollection<Card>();
            Search();
            void Search()
            {
                foreach (var Card in Cards)
                {
                    if (Card.Name.Contains(SearchBox.Text))
                    {
                        FilteredCards.Add(Card);
                    }
                }
            }
            private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                FilteredCards.Clear();
                Search();
            }

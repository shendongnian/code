        private void PokeHead_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PokeHead.Foreground = new SolidColorBrush(Colors.Yellow);
        }
        private void PokeHead_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            PokeHead.Foreground = new SolidColorBrush(Colors.Transparent);
        }
        private void PokeTail_Tapped(object sender, TappedRoutedEventArgs e)
        {
            PokeTail.Foreground = new SolidColorBrush(Colors.Wheat);
        }
        private void PokeTail_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            PokeHead.Foreground = new SolidColorBrush(Colors.Transparent);
        }

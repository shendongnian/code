        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string Button_State = (string) e.Parameter;
            if (Button_State == "Clicked")
            {
                Page2Button.Content = "The button was pressed";
            }
        }

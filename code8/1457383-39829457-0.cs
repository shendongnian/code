        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            string Button_State = "";
            if (Page1Button.Content == "Clicked")
            {
                Button_State = "Clicked";
            }
            this.Frame.Navigate(typeof(Page2), Button_State);
        }

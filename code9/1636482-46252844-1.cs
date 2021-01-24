    ListViewClass.ItemTemplate = new DataTemplate(() =>
    {
      var GoHomeButton = new Button { Text = "Go Home", HorizontalOptions = LayoutOptions.StartAndExpand };
      GoHomeButton.SetBinding(Button.CommandParameterProperty, new Binding("Name"));
      GoHomeButton.Clicked += Gohome;
    //return new view cell 
     }
        private void Gohome(object sender, EventArgs e)
        {      
                Navigation.PushAsync(new Home());
        }

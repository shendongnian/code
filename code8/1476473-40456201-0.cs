    public class ThingToBuy
    {
        public string What { get; set; }
        public string HowLong { get; set; }
    }
    
    items = new List<ThingToBuy>();
    items.Add(new ThingToBuy { What = "Cake", HowLong = "12 hours left!" });
    items.Add(new ThingToBuy { What = "Pie", HowLong = "14 hours left!" });
            var buy = new ContentPage
            {
                Title = "Buy",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new ListView
                        {
                           ItemsSource = items,
                           ItemTemplate = new DataTemplate(() => {
                               var cell = new TextCell();
                               cell.SetBinding(Label.TextProperty, "What");
                               cell.SetBinding(Label.DetailProperty, "HowLong");
                               return cell;
                           })
                        }
                    }
                }
            };

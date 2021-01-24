    using Xamarin.Forms;
    
    namespace BountyApp.Pages
    {
       public class ViewModel
        {
            public string Title { get; set; }
        }
        public class StepperPage : ContentPage
        {
           public ObservableCollection<ViewModel> List { get; set; }
    
            public StepperPage()
            {
                List = new ObservableCollection<ViewModel>();
                List.Add(new ViewModel { Title = "Apple"      });
                List.Add(new ViewModel { Title = "Banana"     });
                List.Add(new ViewModel { Title = "Graps"      });
                List.Add(new ViewModel { Title = "Orange"     });
                List.Add(new ViewModel { Title = "Pineapple"  });
                List.Add(new ViewModel { Title = "Strawberry" });
    
                var listView = new ListView
                {
                    RowHeight = 40, 
                    ItemTemplate = new DataTemplate(typeof(CustomViewCell)),
                    ItemsSource  = List
                };
    
                
                Content = listView;
            }
        }
    }

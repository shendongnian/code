    using Xamarin.Forms;
    
    namespace StackOverflowHelp
    {
        public class EntryStackOverflow : ContentPage
        {
            private StackLayout _stack = new StackLayout();
    
          
            public EntryStackOverflow()
            {
    
                var list = new[]
                {
                    new { title = "testing title" },
                    new {title = "another title"},
                    new {title = "text wraps down to the next line if too long"},
                    new {title = "you get the point"}
                };
    
               
    
                foreach(var n in list)
                {
                    var control = new EntryTextOneLine
                    {
                        EntryText = n.title
                    };
    
                    _stack.Children.Add(control);
                }
    
                Content = _stack;
            }
        }
    }

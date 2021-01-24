    using Xamarin.Forms;
    
    namespace BountyApp.Controls
    {
        public class CustomViewCell : ViewCell
        {
            private Grid _grid = new Grid();
            private Label _lbl = new Label() { HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center };
            private Entry _entry = new Entry();
           
    
            public CustomViewCell()
            {
                _lbl.SetBinding(Label.TextProperty, new Binding("Title"));
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.7, GridUnitType.Star) });
    
                _grid.Children.Add(_lbl, 0, 0);
                _grid.Children.Add(_entry, 1, 0);
    
                View = _grid;
            }
    
        }
    }

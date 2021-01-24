    public class ImageButton : Grid
    {
        private static readonly BooleanToOpacityConverter _converter = new BooleanToOpacityConverter();
        public ImageButton()
        {
            var label = new Label { Text = "ImageButton" };
            var image = new Image { Source = ImageSource.FromFile("icon.png") };
            // add binding to Opacity using IsEnabled from parent
            label.SetBinding(OpacityProperty, new Binding("IsEnabled", converter: _converter, source: this));
            image.SetBinding(OpacityProperty, new Binding("IsEnabled", converter: _converter, source: this));
            ColumnDefinitions = new ColumnDefinitionCollection { new ColumnDefinition(), new ColumnDefinition() };
            SetColumn(label, 1);
            Children.Add(label);
            Children.Add(image);
        }
    }

    public class NGrid : Grid
    {
        public NGrid()
        {
            _textBox = new TextBox { Visibility = Visibility.Hidden };
            _label = new Label();
            _textBox.KeyDown += _textBox_KeyDown;
            Children.Add(_textBox);
            Children.Add(_label);
        }
        private void _textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (_isEditMode && e.Key == Key.Return)
            {
                _textBox.Visibility = Visibility.Hidden;
                _label.Content = _textBox.Text;
            }
        }
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2 && _isEditMode == false)
            {
                _textBox.Visibility = Visibility.Visible;
                Keyboard.Focus(_textBox);
            }
            base.OnMouseDown(e);
        }
        bool _isEditMode;
        TextBox _textBox;
        Label _label;
    }

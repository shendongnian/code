    var button = new Button();
    button.Content = "123";
    button.HorizontalAlignment = HorizontalAlignment.Left;
    button.Measure(new Size(100, 100));
    button.Arrange(new Rect(0, 0, 100, 100));
    MessageBox.Show(button.ActualWidth.ToString()); // Output: 23,41

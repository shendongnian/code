    public Label FindLabel(CheckBox checkBox)
    {
       var listView = VisualTreeHelper.GetParent(checkBox);
       while (listView.GetType() != typeof(ListView))
       {
           listView = VisualTreeHelper.GetParent(listView);
       }
       return (listView as FrameworkElement).FindName("vLabel") as Label;
    }

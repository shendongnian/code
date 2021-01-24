    public class NumderDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            string numberStr = item as string;
    
            if (numberStr != null)
            {
                int num;
                Window win = Application.Current.MainWindow;
    
                try
                {
                    num = Convert.ToInt32(numberStr);
                }
                catch
                {
                    return null;
                }
    
                // Select one of the DataTemplate objects, based on the 
                // value of the selected item in the ComboBox.
                if (num < 5)
                {
                    return win.FindResource("numberTemplate") as DataTemplate;
                }
                else
                {
                    return win.FindResource("largeNumberTemplate") as DataTemplate;
    
                }
            }
    
            return null;
        }
    
    }

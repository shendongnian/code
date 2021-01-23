    public class Class1
    {
        public static void Demo()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Text", "Caption", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if(dialogResult == MessageBoxResult.Yes)
            {
                MessageBox.Show("Yes was clicked");
            }
            else 
            {
                MessageBox.Show("No was clicked");
            }
        }
    }

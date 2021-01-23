    public class WindowHandler
    {
        public void ShowWindow(object dataContext, int height, int width)
        {
            Window window = new Window()
            {
                Content = dataContext,
                Width = width,
                Height = height
            };
            window.Show();
        }
    }

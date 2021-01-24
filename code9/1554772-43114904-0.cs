    public class CustomGrid : DataGrid
    {
        private List<Model> models;
        public CustomGrid()
        {
            Loaded += (s,e) => models = ItemsSource as List<Model>;
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (models == null)
                return;
            Model model = CurrentItem as Model;
            if (model == null)
                return;
            int index = models.IndexOf(model);
            switch (e.Key)
            {
                case Key.Down:
                    //is the next model disabled?
                    if (index < models.Count - 1 && !models[index + 1].enabled)
                        e.Handled = true;
                    break;
                case Key.Up:
                    if (index > 0 && !models[index - 1].enabled)
                        e.Handled = true;
                    break;
            }
        }
    }

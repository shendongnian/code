    public string GetValueById(string id, string value)
    {
        return Application.Current.Dispatcher.Invoke(() =>
        {
            var main = Application.Current.MainWindow as MainWindow;
            if (main != null)
            {
                return main.GetValue(id);
            }
        });
    }

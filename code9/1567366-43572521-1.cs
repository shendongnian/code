    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        Task.Factory.StartNew(() => { StartSTATask(create); });
    }
    bool create()
    {
        Button btn = new Button();
        btn.Content = "Press me";
        using (var stream = System.IO.File.Create(@"g:\\button.xaml"))
            System.Windows.Markup.XamlWriter.Save(btn, stream);
        return true;
    }
    public static Task<bool> StartSTATask(Func<bool> func)
    {
        var tcs = new TaskCompletionSource<bool>();
        var thread = new Thread(() =>
        {
            try
            {
                var result = func();
                tcs.SetResult(result);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        return tcs.Task;
    }
    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        using (var stream = System.IO.File.OpenRead(@"g:\\button.xaml"))
        {
            Button btn = System.Windows.Markup.XamlReader.Load(stream) as Button;
            Lbl.Content = btn;
        }
    }

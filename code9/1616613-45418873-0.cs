    var someNewInput = CalculateNewInput();
    System.Windows.Application.Current.Dispatcher.Invoke(
            System.Windows.Threading.DispatcherPriority.DataBind, (System.Action)delegate
            {
                readInTxtBox.Text += someNewInput;
            });

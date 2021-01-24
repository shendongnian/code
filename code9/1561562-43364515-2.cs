    private void btnTrain_Click(object sender, RoutedEventArgs e)
    {
        string myText = txtbTrainPath.Text;
        Task.Factory.StartNew( () => { StartTrain(myText); } );
    }

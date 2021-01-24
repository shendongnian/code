    private void Dynamicbutton1_Click(object sender, RoutedEventArgs e) {
        var DynamicButton1 = sender as Button;//this casts the sender to the desired type
        passedinfoArray[0] = DynamicButton1.Content as string; //Or DynamicButton1.Content.ToString();
        classB bClass = new classB(passedinfoArray);
        this.Close();
        showTour.ShowDialog();
    }

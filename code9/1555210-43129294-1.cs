    private void ChosenNumber_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter && chosenNumber.Text != String.Empty)
        {
            //catalog.OpenFileByNumber(ConvertToInt(numeroEscolhido.Text));
            //catalog.OpenSelectedFile(); // Will become someting like this
            chosenNumber.Text = String.Empty;            
            vm.OpenSelectedFile;
        }
    }

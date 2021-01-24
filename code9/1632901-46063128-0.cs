    private void MyMethod(object sender, EventArgs e)
    {
        if (myTextBox.Text.Length == myTextBox.MaxLength)
        {
            System.Diagnostics.Debug.WriteLine($"caret is at {myTextBox.CaretIndex}");
        }
    }

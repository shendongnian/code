    public async Task ProcessNames(string[] names) {
    
        var message = String.Join(" ", names) + " ";
    
        txtBoxCourse.Text = message;
        var dialog = new MessageDialog(message);
        await dialog.ShowAsync();
    
    }

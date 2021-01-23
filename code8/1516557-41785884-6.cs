    private async Task displayCourseInfo(string[] names) {
        //Replaced for loop with this line;
        var message = String.Join(" ", names);
    
        txtBoxCourse.Text = message;
        var dialog = new MessageDialog(message);
        await dialog.ShowAsync();    
    }

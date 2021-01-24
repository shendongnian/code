    async void ShowLabelForCertainTime( Label label, int milliseconds )
    {
       label.Visible = true;
       await Task.Delay( milliseconds ); //Time in milliseconds
       label.Visible = false;
    }

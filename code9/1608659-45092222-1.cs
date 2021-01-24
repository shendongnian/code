    spinner.ItemSelected += (sender, e) => {
        var itemSelected = (string) spinner.SelectedItem;
        if (itemSelected == "1")
        {
            textView.Text = "Clicked 1";
        }
        else if (itemSelected == "2")
        {
            textView.Text = "Clicked 2";
        }
    };

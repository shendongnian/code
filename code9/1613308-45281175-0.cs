    private async void control_SelectionValueChanged(Object sender, EventArgs e) {
        SomeMethodA(); //On UI
        bool variable = await SomeOtherMethodAsync(); // Non blocking
        //Back on UI
        if ( variable ) SomeMethodB();
        SomeMethodC();
    }

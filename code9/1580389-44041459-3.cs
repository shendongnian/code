    public async void OnButton1_clicked(object sender, ...)
    {
        await this.UpdateData();
        // I chose to split the event from the action, so others like menu items
        // could also call UpdateData();
        // Besides it is a nice example of a function that returns Task instead of void 
    }

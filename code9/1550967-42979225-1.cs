    //new code
    public void myEventHandler(object sender, EventArgs e)
    {      
       LabelResult.Text = Order.Preference(myDrinkOfChoice.Text, myFoodOfChoice.Text);
    }

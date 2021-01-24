    // declare this method outside of the constructor
    private void UpdateLabel() {
    
      totalLabel.Text = "You have ordered " + movieamount  + " " +
        pickmovie + " \n You will be paying with " + paymentSelected + " " +
        "Your delivery will be delivered at " + dateSelected + " " +   
        timeSelected;
    }
    
    // then modify these existing handlers to call UpdateLabel
    stepper.ValueChanged += (sender, e)=>
    {
      movieamount = stepper.Value.ToString();
      UpdateLabel();
    };
    
    // you should also call UpdateLabel in the other handlers that update values
    button.Clicked += (sender, args) =>
    {
      UpdateLabel();
    }; 

    private ButtonClicked(Parameter object)
    {
       SelectedItem.UsingIt();
       if(object is YourButtonDataContext){
            YourButtonDataContext.UsingIt();
       }
    }

        //create "reference to your layout"
        LinearLayout yourFormLayout = FindViewById<LinearLayout(Resource.Id.Linear_MS);
    
        //create container for parameters
        var parameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
        //add some parameters
        param.SetMargins(20, 20, 20, 10);
        //create new element
        Button button = new Button(this);
            button.Text = "click me";
            button.SetBackgroundColor(Android.Graphics.Color.Black);
            button.SetTextColor(Android.Graphics.Color.White);
            button.LayoutParameters = parameters;
    
        //add some events to your element
        button.Click += (sender, e) => DoStuff();
        
            //Add the button
            yourFormLayout.AddView(button);

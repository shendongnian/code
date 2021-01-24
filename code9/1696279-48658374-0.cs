    public App ()
        {
            var buttonStyle = new Style (typeof(Button)) {
                Setters = {
                    ...
                    new Setter { Property = Button.TextColorProperty,   Value = Color.Teal }
                }
            };
    
            Resources = new ResourceDictionary ();
            Resources.Add ("blueButton", buttonStyle);
            ...
        }

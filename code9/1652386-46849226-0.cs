    @for (int i = 0; i < Model.GetType().GetProperties().Count(); i++)
    {
        if(Model.GetProperties[i].PropertyType.Name == "String"){
            // add an editor or a textbox
        }
        else if(Model.GetProperties[i].PropertyType.Name == "DateTime"){
           // add a datetime picker
        }
    }

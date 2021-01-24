    if(GUILayout.Button("Attach script"))
    {
        // check if type is contained in your assembly:
        Type type = typeof(MeAssemblyType).Assembly.GetTypes().FirstOrDefault(t => t.Name == scriptname);
        if(type != null)
        {
            // script exists in the same assembly that MeAssemblyType is
            obj.AddComponent(type); // add the component
        }
        else
        { 
            // display some error message
        }
    }

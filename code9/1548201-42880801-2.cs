    enum SupportedTypes
    {
        Color,
        Int
    }
    SupportedTypes selectedType;
    void OnEnable()
    {
        // If the user still didn't select anything, select Int
        selectedType = SupportedTypes.Int;
        // See below to know what this is
        methodUsedToDrawTheLastPart = DrawIntChooser;
    }
    // One field for each type
    // Not elegant but we don't know the type beforehand
    Color colorValue;
    int intValue;
    // ...
    // Delegate defining a method signature: in this case "void XXX(string)"
    delegate void SetValue(string propertyId);
    // Instance of the delegate: think of it as a pointer to a method
    //   with the signature defined earlier
    // You can set this field to any method being "void XXX(string)"
    SetValue methodUsedToDrawTheLastPart;
    // Then One method to draw each property chooser
    // They will just draw the last part of the modifier
    void DrawColorChooser(string propertyId)
    {
        Color newColorValue = EditorGUILayout.ColorField(colorValue);
        if (newColorValue != colorValue)
        {
            colorValue = newColorValue;
            // Replace this with a call to the renderer
            Debug.Log("Set color to " + colorValue);
        }
    }
    void DrawIntChooser(string propertyId)
    {
        int newIntValue = EditorGUILayout.IntField(intValue);
        if (newIntValue != intValue)
        {
            intValue = newIntValue;
            Debug.Log("Set int to " + intValue);
        }
    }
    // All the other types choosers ...
    // Finally, the method to put pieces together
    void DrawModifier()
    {
        EditorGUILayout.BeginHorizontal();
        string propertyId = "propId";
        EditorGUILayout.TextField(propertyId);
        SupportedTypes newModifierType = (SupportedTypes)EditorGUILayout.EnumPopup(selectedType);
        // We only do if-else statements if the type changed
        // So when the user changes only the value, this will be skipped
        if (newModifierType != selectedType)
        {
            // Here, based on the chosen type, we set the delegate
            if (newModifierType == SupportedTypes.Int)
            {
                methodUsedToDrawTheLastPart = DrawIntChooser;
            }
            else if (newModifierType == SupportedTypes.Color)
            {
                methodUsedToDrawTheLastPart = DrawColorChooser;
            }
            selectedType = newModifierType;
        }
        // And then we call it
        methodUsedToDrawTheLastPart(propertyId);
        EditorGUILayout.EndHorizontal();
    }
    public override void OnInspectorGUI()
    {
        DrawModifier();
    }

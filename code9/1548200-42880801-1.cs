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
        if(newColorValue != colorValue)
        {
            colorValue = newColorValue;
            renderer.material.SetColor(propertyId, colorValue);
        }
    }
    void DrawIntChooser(string propertyId)
    {
        int newIntValue = EditorGUILayout.IntField(intValue);
        if(newIntValue != intValue)
        {
            intValue = newIntValue;
            renderer.material.SetInt(propertyId, intValue);
        }
    }
    // All the other types choosers ...
    // Finally, the method to put pieces together
    void DrawModifier()
    {
        EditorGUILayout.BeginHorizontal();
        propertyId = EditorGUILayout.TextField(propertyId);
        Type newModifierType = /* Your method to obtain the */ modifierType;
        // We only do if-else statements if the type changed
        // So when the user changes only the value, this will be skipped
        if (newModifierType != modifierType)
        {
            // Here, based on the chosen type, we set the delegate
            if (newModifierType == typeof(int))
            {
                methodUsedToDrawTheLastPart = DrawIntChooser;
            }
            else if (newModifierType == typeof(Color))
            {
                methodUsedToDrawTheLastPart = DrawColorChooser;
            }
        }
        // And then we call it
        methodUsedToDrawTheLastPart(propertyId);
        EditorGUILayout.EndHorizontal();
    }

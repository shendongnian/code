    char[] array = step.ToString().ToCharArray();
    Debug.Log(array);
    for (int i = 0; i < array.Length; i++)
    {
        GUI.DrawTexture(new Rect(0 + i * 30, 0, 20, 30), numberTextures[(int)char.GetNumericValue(array[i])]);
    }

    /// <summary>
    /// Handle hardware keys (from KeyboardHookRender.cs in iOS project)
    /// </summary>
    /// <param name="keys">Keys sent, including trailing Cr or Lf</param>
    public void HandleHardwareKeyboard(string keys)
    {
        SomeTextbox.Text = keys;
        // Whatever else you need to do to handle it
    }

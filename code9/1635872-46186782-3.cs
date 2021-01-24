    /// <summary>
    /// Calculates and sets the correct start location for a dialog to appear.
    /// </summary>
    /// <param name="form">The dialog to be displayed</param>
    /// <param name="screen">Desired screen</param>
    public static void SetStartLocation(Form form, Screen screen)
    {
               form.StartPosition = FormStartPosition.Manual;
        // Calculate the new top left corner of the form, so it will be centered.
        int newX = (screen.WorkingArea.Width - form.Width) / 2 + screen.WorkingArea.X;
        int newY = (screen.WorkingArea.Height - form.Height) / 2 + screen.WorkingArea.Y;
        form.Location = new Point(newX, newY);
    }

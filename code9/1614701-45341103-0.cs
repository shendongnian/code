    private void bigButton_MouseDown(object sender, MouseEventArgs e) {
        if (littleButton.Bounds.Contains(littleButton.Parent.PointToClient(Cursor.Position))) {
            littleButton_Click(littleButton, EventArgs.Empty);
            return;
        }
            
        // Any code needed for MouseDown actually on big button goes here:
    }

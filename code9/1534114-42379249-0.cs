    List<Control> controlsToRemove = new List<Control>();
    foreach (Control item in monitorLayoutPanel.Controls.OfType<PictureBox>()) {
        controlsToRemove.Add(item);
    }
    foreach (Control item in monitorLayoutPanel.Controls.OfType<Label>()) {
        controlsToRemove.Add(item);
    }
    foreach (Control item in controlsToRemove) {
        monitorLayoutPanel.Controls.Remove(item);
        item.Dispose();
    }

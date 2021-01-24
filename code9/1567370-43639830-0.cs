    void SetupInkToolbar(this InkToolbar toolbar, InkToolbarTool tool, Color color, double thickness)
    {
        InkToolbarToolButton button = toolbar.GetToolButton(tool);
        if (button is InkToolbarPenButton typed) // Only adjust the UI if the tool is either a pen, a pencil or an highlighter
        {
            Color[] colors = typed.Palette.Select(p => (p as SolidColorBrush)?.Color ?? Colors.Black).ToArray();
            int index = colors.IndexOf(c => c.Equals(color));
            if (index >= 0) typed.SelectedBrushIndex = index; // Get the right brush index for the given color
            typed.SelectedStrokeWidth = thickness; // Adjust the brush thickness too
        }
        toolbar.ActiveTool = button;
    }

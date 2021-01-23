    private void HookupNavigationButtons(Control ctrl)
    {
        for (int t = ctrl.Controls.Count - 1; t >= 0; t--)
        {
            Control c = ctrl.Controls[t];
            c.PreviewKeyDown -= HandlePreviewKeyDown;
            c.PreviewKeyDown += HandlePreviewKeyDown;
            c.MouseDown -= HandleMouseDown;
            c.MouseDown += HandleMouseDown;
            HookupNavigationButtons(c);
        }
    }

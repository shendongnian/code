    public void LoadGraphics(GraphicsData gfx)
    {
        if (gfx.Size != null) { _customControl.Size = gfx.Size.Value; }
        if (gfx.Location != null) { _customControl.Location = gfx.Location.Value }
        if (gfx.Anchor != null) { _customControl.Anchor = gfx.Anchor.Value; }
        if (gfx.BackColor != null) { _customControl.BackColor = gfx.BackColor .Value; }
        if (gfx.BackgroundImage != null) { _customControl.BackgroundImage = gfx.BackgroundImage; }
        if (gfx.Cursor != null) { _customControl.Cursor = gfx.Cursor; }
        if (gfx.Font != null) { _customControl.Font = gfx.Font; }
        if (gfx.Color != null) { _customControl.Color = gfx.Color.Value; }
        if (gfx.Enabled != null) { _customControl.Enabled = gfx.Enabled.Value; }
        if (gfx.Visible != null) { _customControl.Visible = gfx.Visible.Value; }
    }

    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        e.DrawBackground();
        var color = GetDesiredColor(e.Index); // TODO: Implement it for yourself
        TextRenderer.DrawText(e.Graphics, tabControl1.TabPages[e.Index].Text, e.Font, e.Bounds, color);
    }

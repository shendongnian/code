    private int hoveredIndex = -1;
    private Size imageSize = new Size(16, 16);
    private void TabControl1_MouseMove(object sender, MouseEventArgs e)
    {
        for (int i = 0; i < tabControl1.TabPages.Count; i++)
        {
            Rectangle rect = tabControl1.GetTabRect(i);
            Rectangle closeButton = GetImageLocation(rect);
            if (closeButton.Contains(e.Location))
            {
                if (hoveredIndex != i)
                {
                    hoveredIndex = i;
                    tabControl1.Invalidate(rect);
                }
            }
            else if (hoveredIndex == i)
            {
                tabControl1.Invalidate(tabControl1.GetTabRect(hoveredIndex));
                hoveredIndex = -1;
            }
        }
    }
    private void TabControl1_MouseLeave(object sender, EventArgs e)
    {
        if (hoveredIndex != -1)
        {
            tabControl1.Invalidate(tabControl1.GetTabRect(hoveredIndex));
            hoveredIndex = -1;
        }
    }
    private Rectangle GetImageLocation(Rectangle rect)
    {
        return new Rectangle(rect.Right - imageSize.Width, rect.Top, imageSize.Width, imageSize.Height);
    }
    private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
    {
        Image image = e.Index == hoveredIndex ? imageHovered : imageNormal;
        e.Graphics.DrawImage(image, GetImageLocation(e.Bounds));
    }

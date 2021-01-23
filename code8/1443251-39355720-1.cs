    private void container_Scroll(object sender, ScrollEventArgs e)
    {
        var p = container.AutoScrollPosition;
        var labels = container.Controls.OfType<Label>().OrderBy(x => x.Top);
        var top = labels.Where(l => container.ClientRectangle.IntersectsWith(l.Bounds))
                        .FirstOrDefault();
        if (top != null)
        {
            this.Text = top.Name;
            top.BackColor = Color.Gold;
            labels.Except(new[] { top }).ToList().ForEach(x => x.BackColor = Color.Silver);
        }
    }

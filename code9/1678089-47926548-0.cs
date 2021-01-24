    for (int i = Controls.Count - 1; i >= 0; i--)
    {
        Control item = Controls[i];
        if (item.Name.Contains("dynamicButton"))
        {
            Controls.Remove(item);
        }
    }

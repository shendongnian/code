    public void RemoveTaskPaneWithTitle()
    {
        for (int i = this.CustomTaskPanes.Count; i > 0; i--)
        {
            ctp = this.CustomTaskPanes[i - 1];
            if (ctp.Title == "Your title")
            {
                 this.CustomTaskPanes.RemoveAt(i - 1);
            }
         }
      }

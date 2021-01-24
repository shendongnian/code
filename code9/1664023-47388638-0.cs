    public void FirstRegister()
    {
        if (content != null)
        {
            content.FirstRegister();
        }
        else
        {
            MainFrame.ContentRendered += (s, e) =>
            {
                if (content != null)
                    content.FirstRegister();
            };
        }
    }

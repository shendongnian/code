    public void DisplayForm(CommonType f)
    {
        using(var form = f.View())
        {
            form.ShowDialog(view);
        }
    }

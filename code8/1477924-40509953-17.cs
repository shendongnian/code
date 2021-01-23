    public void RemoveIcon()
    {
        foreach (int i = MyContactInst.Count-1; i >= 0 ; i--)
        {
            if (icon.IsSelected == true)
            {
                MyContactInst.Remove(icon);
            }
        }
     }

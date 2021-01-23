    public void RemoveIcon()
    {
        foreach (Icon icon in MyContactInst)
        {
            if (icon.IsSelected == true)
            {
                MyContactInst.Remove(icon);
            }
        }
     }

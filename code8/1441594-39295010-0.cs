    foreach (Category item in context.Category.Local)
    {
        //MessageBox.Show(item.Name);      
    }
<!---->
    for (int i = 0; i < context.Category.Local.Count; i++)
    {
        var item = context.Category.Local[i];
        //MessageBox.Show(item.Name);
    }

    public List<string> SelectedColorsList
    {
        get
        {
            return SelectedColors.ToString()
                   .Split(new[] { ", " }, StringSplitOptions.None)
                   .ToList();
        }
        set
        {
            if (value == null)
            {
                 this.SelectedColors = MyColors.None;
                 return;
            }
            int s = 0;
            foreach (var v in value)
            {
                s += (int)Enum.Parse(typeof(MyColors), v);
            }
            this.SelectedColors = (MyColors)s;
        }
    }

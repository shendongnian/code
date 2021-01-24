    public void AddItem()
    {
        var temp = new List<string>(this.ComboBoxItems);
        temp.Add("abc" + (++this.counter));
        this.ComboBoxItems = temp;
    }

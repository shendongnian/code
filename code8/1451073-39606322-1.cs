    private void CreateTable(IList<IITem> array)
    {
        foreach (var item in array)
        {
            //Problem is here **** when trying to get item.tag
            var text = new TextBox(){ Text = item.Tag , ID = item.TagID.ToString() };
        }
    }

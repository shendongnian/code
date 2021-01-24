    public List<Button> GetAllButtons(Form f)
    {
        List<Button> resultList = new List<Button>();
        foreach(Control a in f.Controls)
        {
            if(a is Button)
            {
                resultList.Add((Button)a);
            }
        }
        return resultList;
    }

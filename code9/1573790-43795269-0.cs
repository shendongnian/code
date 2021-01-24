    public void addCatToList(List<SelectedItemList> list, int depth, IEnumerable<Category> cats){
        foreach (Category item in cats)
        {
            list.Add(new SelectListItem { Value = item .Id.ToString(), Text = printDash(depth) + item.Name });
            addCatToList(list, depth + 1, item.SubCategories);
        }
    }
    private string printDash(int number){
        string dash = string.Empty;
        for(int i = 0; i < number; ++i){
            if (i == 0)
                dash += " ";
            dash += "- ";
        }
        return dash;
    }

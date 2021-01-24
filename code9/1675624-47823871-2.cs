    public MyPage()
    {
        EditItem = new Command((parameter) => {
            ListItem item = (ItemList)parameter as ItemList;
    
            if (item == null)
                return; // TODO error handling
    
            item.Large = false;
        });
    }

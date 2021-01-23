    MyList list;
    public IList<int> UsersMessaged {
        get {
            return myList ?? (myList = new MyList(this));
        }
    }

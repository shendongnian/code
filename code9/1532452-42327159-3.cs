    private MyLovelyEnum _enum;
    public MyLovelyEnum VeryLovelyEnum
    {
        get
        {
            return _enum;
        }
        set
        {
            _enum = value;
            switch (value)
            {
                case MyLovelyEnum.Person:
                    CurrentSelectedContent = new Person();
                    break;
                //...
            }
            OnPropertyChanged("VeryLovelyEnum");
        }
    }

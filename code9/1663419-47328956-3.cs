        private long _CategoryID;
        
        public long CategoryID
        {
            get
            {
                return _CategoryID;
            }
            set
            {
                _CategoryID = value;
                if((int)CategoryID > CategoriesList.Count -1)
                {ComboSelection= CategoriesList[0];}
                else
                {ComboSelection= CategoriesList[(int)CategoryID ];
                 _CategoryID = 0;}
                RaisePropertyChanged("CategoryID");
            }
        }

        public bool IsSelected
        {
            get
            {
                var tabitem = Parent as TabItem;
                return tabitem != null && tabitem.IsSelected;
            }
        }

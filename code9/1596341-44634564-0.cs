    private int _npages = -1;
    public int CountOP///////count of pages
        {
            get
            {
                if(_npages == -1)
                    _npages = number_of_pages(Count_Per_Page);
                return _npages;
            } 
        }

    public void add(float x, int pos)
    {
        if(pos == 0)
        {
            // create a new root and point the new root to the existing root
        }
        else
        {
            Element tmp = first;
            for(int i = 0; i < pos; i++)
            {
                tmp = tmp.next;
            }
    
            // create new element
            // set new element next property to tmp.next
            // set tmp.next to new element
        }
    }

    private void UpdateList(List<Object> newList)
    {
      //only read operation on global list, adding  items only to local list  
      newList.AddRange(m_globalCopyOfList);  
      //reference assignment is atomic
      m_globalCopyOfList = newList;
    }
    
    private int GetTotalCount()
    {
       //reference assignment is atomic
       var localCopyOfList = m_globalCopyOfList; 
       //if UpdateList method is called anytime during below operation, 
       //m_globalCopyOfList ref will point to new list, localCopyOfList will not 
       //be touched.  
    return localCopyOfList.where(x => x.status == true).Count;
    }

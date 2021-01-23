    private void FilterData(ref List<Retailer> data)
    {
       for(int i = 0 ; i < data.Count ; i++)
      {
         Retailer d = data[i];
         DateTime present=DateTime.parse(present);
         DateTime past = DateTime.parse(past);
         DateTime dt = DateTime.parse(d.Date);
    
         if(!(dt >= past && dt < present))
           data.RemoveAt(i);  //remove record it is not between present and past
    
      }
           
    }

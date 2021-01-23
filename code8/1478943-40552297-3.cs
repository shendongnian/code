      public ActionResult SelectedDropDownValueLogic(string dropdownValue,string dropdownKey)
        {
    
    	   //Do Logic ..
    	      Func<AggregateClass, ModelClass> buildModel = x => new ModelClass()
                  {
                     Property = x.Property,
                  };
    	  
    	              etc.....ForEach(x => model.ListOfObjects.Add(buildModel(x))
    	   //Do Logic ..

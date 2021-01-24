    public IEnumberable<whatever> GetWhatevers(){
        if (_dependentList == null || _dependentList.Count == 0) {
            throw new InvalidOperationException("Unable to process without whatevers");
        }
    
        return GetWhatevers_Impl();
    }
    
    private IEnumberable<whatever> GetWhatevers_Impl(){
         while (true) {      
            // do calculations
            yield return myWhatever
        }
    }

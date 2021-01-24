     public void timeConsumingMethod(DataObject data) {
       // When designing public methods do not forget about validation
       if (null == data)
         throw new ArgumentNullException("data");
       // Think on awaiting the Task returned
       data.TheMethod();  
       ...
     }

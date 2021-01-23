    public Model.V_PWT_APP_ALL selectedApp: IOberver<App>
    {
         List<Control> ControlsToBeUpdated = new List<Control>() //Each control that needs updated should implement and interface that has an .Update(type T) method where T is whatever value needs updated.
         public void OnCompleted()
         {
              //...notify taskBar, etc. 
         }
    
         public void OnError(Exception error)
         {
             //handle exception, update log, etc.
         }
    
         public void OnNext(object value)
         {
             foreach (var control in ControlsToBeUpdated) control.Update(value);
         }
    }

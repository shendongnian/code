    using Windows.Devices.Gpio;
    
    public void GPIO()
    
    {
        
           // Get the default GPIO controller on the system
    
           GpioController gpio = GpioController.GetDefault();
        
           if (gpio == null)
               return; // GPIO not available on this system
    
           
          // Open GPIO 5
        
          using (GpioPin pin = gpio.OpenPin(5))
          
          {
            // Latch HIGH value first. This ensures a default value when the pin is set as output
            
             pin.Write(GpioPinValue.High);
    
            // Set the IO direction as output
            pin.SetDriveMode(GpioPinDriveMode.Output);
    
         } // Close pin - will revert to its power-on state
    
    }

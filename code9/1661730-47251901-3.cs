            Hardware hardware = new Hardware();
            
            hardware.Id = 1 //Set your unique Id here
            hardware.Nodes = 55; //Not necessary
            hardware.Repeaters = 46; //Not necessary
            hardware.Hubs = 82; //Not necessary
            RemoveHardware(hardware);
            // So edit your RemoveHardware method too like this
            public void RemoveHardware(T item)
            {
               MDM.Set<T>().Attach(item);
               MDM.Set<T>().Remove(item);
               MDM.SaveChanges();
            }

         private void OnTimedEvent(object sender, ElapsedEventArgs e)
                {
                    Dispatcher.Invoke(() =>
                    {
                        DataColl.Add(new DataClass() { ID = index, time = string.Format("{0:HH:mm:ss tt}", DateTime.Now), source = "AIS" });
                        index++;
                    });   
               }
          
    
            

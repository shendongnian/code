         public Kiosk()
        {
            Init();
            hook();
            var updateTask = Update();
            updateTask.Wait();
        }
 
          public async Task Update()
            {           
             do
             {
                //CODE HERE
                 await Task.Delay(5000);
             } while (true);
            }

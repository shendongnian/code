     public static async Task FireTrigger(int hours, int minutes, int seconds)
        {
            do
            {
                if (DateTime.Now.Hour == hours && DateTime.Now.Minute == minutes && DateTime.Now.Second == seconds)
                {
                    // Call trigger!
                   
                }
                await Task.Delay(990);
            }
            while (true);
        } 

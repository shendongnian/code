    private static async Task<string> MyNewTask()
        {
            int timer;
 
            for (timer = 0; timer < 10; timer++)
            {
                Console.WriteLine(timer);
            }
 
            return "Time left = " + timer;
        }

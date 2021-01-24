         public void LongRunningHubMethod()
        {
            //THIS COULD BE SOME LIST OF DATA
            int itemsCount = 100;
            for (int i = 0; i <= itemsCount; i++)
            {
                //SIMULATING SOME TASK
                Thread.Sleep(500);
                //CALLING A FUNCTION THAT CALCULATES PERCENTAGE AND SENDS THE DATA TO THE CLIENT
                Functions.SendProgress(Context.ConnectionId, "Process in progress...", i, itemsCount);
            }
        }

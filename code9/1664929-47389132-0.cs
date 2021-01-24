    var task1 = new Task(async () =>
    {
        while (true)
        {
            try
            {
                DoWork();
                await Task.Delay(2000, _ct1.Token);
                count++;
                if (count >= 5)
                {
                    throw new NotImplementedException();
                }
            }
            catch (TaskCanceledException ex)
            {
                //Log cancellation and do not continue execution
                Console.WriteLine("DoWork cancelled: " + ex.Message);
                break;
            }
            catch (Exception ex)
            {
                //Log error and continue with execution
                Console.WriteLine("Error occurred at DoWork");
                count = 0;  //  without this you'll have exception thrown on each of further iterations
            }
        }
    }, _ct1.Token, TaskCreationOptions.LongRunning);

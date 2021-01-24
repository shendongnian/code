        private async void SyncMethodWrapper(int id, int millis)
        {
            Console.WriteLine($"Start task {id}");
            SemaphoreSlim ss = new SemaphoreSlim(0);
            bool done = false;
            System.Timers.Timer timer = null;
            Stopwatch sw = null;
            var task = Task.Run(() =>
            {
                timer = new System.Timers.Timer {Interval = millis + 100};
                sw = new Stopwatch();
                timer.Elapsed += (sender, args) =>
                {
                    try
                    {
                        ss.Release(1);
                        Console.WriteLine($"Timeout {id}");
                    }
                    catch (Exception)
                    {
                    }
                };
                timer.Start();
                sw.Start();
                Console.WriteLine($"start timer {id}");
                SyncMethod(millis, id);
                done = true;
                ss.Release(1);
                //Console.WriteLine("done");
            }
                );
            await ss.WaitAsync().ConfigureAwait(false);
            Console.WriteLine($"ID = {id} done = {done} elapsed = {sw.Elapsed}");
            ss.Dispose();
            timer.Dispose();
        }
    }

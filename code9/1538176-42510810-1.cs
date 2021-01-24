    Task t = Task.Run(() =>
            {
                var run = true;
                while (run)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            run = false;
                            break;
                        }
                       //loop code
                    } 
                }
            }, token);

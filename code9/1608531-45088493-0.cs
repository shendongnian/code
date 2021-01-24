            var maxsize = 50;
            var tasks = new List<Task>();
            for (int index = 0; index < int.MaxValue; index++)
            {
                tasks.Add(CallRequestsAsync(param1[index], param2[index]));
                if (tasks.Count > maxsize)
                    Task.WaitAll(tasks.ToArray());
            }

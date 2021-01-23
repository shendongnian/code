        private Action<WorkItem<Location,PointToLocation>> CreateProcessingAction()
        {
            return new Action<WorkItem<Location,PointToLocation>>(async i => {
                var sw = new Stopwatch();
                sw.Start();
                var taskItem = ((WorkItem<Location,PointToLocation>)i);
                var inputData = taskItem.InputData;
                //Log($"Consuming: {inputData.Latitude},{inputData.Longitude} {DateTime.UtcNow:mm:ss:ff}");
                //-- Assume calling another async method e.g. await httpClient.DownloadStringTaskAsync(url);
                await Task.Delay(500);
                sw.Stop();
                Location outData = new Location()
                {
                    Latitude = inputData.Latitude,
                    Longitude = inputData.Longitude,
                    StreetAddress = $"Consumed: {inputData.Latitude},{inputData.Longitude} Duration(ms): {sw.ElapsedMilliseconds}"
                };
                taskItem.Complete(outData);
                //Console.WriteLine($"Consumed: {taskItem.url} {DateTime.UtcNow}");
            });
        }

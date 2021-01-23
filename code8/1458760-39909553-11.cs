        int startRange = 0;
        int nextRange = 1000;
        ThrottledProducerConsumer<WorkItem<Location,PointToLocation>> tpc;
        private void cmdTestPipeline_Click(object sender, EventArgs e)
        {
            Log($"Pipeline test started {DateTime.Now:HH:mm:ss:ff}");
            if(tpc == null)
            {
                tpc = new ThrottledProducerConsumer<WorkItem<Location, PointToLocation>>(
                    //1010, 2, 20000,
                    TimeSpan.FromMilliseconds(1010), 45, 100000,
                    CreateProcessingAction(),
                    2,45,10);
            }
            var workItems = new List<WorkItem<Models.Location, PointToLocation>>();
            foreach (var i in Enumerable.Range(startRange, nextRange))
            {
                var ptToLoc = new PointToLocation() { Latitude = i + 101, Longitude = i + 100 };
                var wrkItem = new WorkItem<Location, PointToLocation>(ptToLoc);
                workItems.Add(wrkItem);
                wrkItem.Task.ContinueWith(t =>
                {
                    var loc = t.Result;
                    string line = $"[Simulated:{DateTime.Now:HH:mm:ss:ff}] - {loc.StreetAddress}";
                    //txtResponse.Text = String.Concat(txtResponse.Text, line, System.Environment.NewLine);
                    //var lines = txtResponse.Text.Split(new string[] { System.Environment.NewLine},
                    //    StringSplitOptions.RemoveEmptyEntries).LongCount();
                    //lblLines.Text = lines.ToString();
                    //Log(line);
                });
                //}, TaskScheduler.FromCurrentSynchronizationContext());
            }
            startRange += nextRange;
            tpc.EnqueueItemsAsync(workItems);
            Log($"Pipeline test completed {DateTime.Now:HH:mm:ss:ff}");
        }

    private void Method()
    {
        Task.Run(async () =>
        {
            while (HasUnvisitedNeighbours())
            {
                await Application.Current.Dispatcher.BeginInvoke(new Action(() => CurrentTile.Draw()));
                await Task.Delay(500);
                List<char> Keys = new List<char>(CurrentTile.Neighbours.Keys);
                char randomKey = Keys[rnd.Next(Keys.Count)];
                CurrentTile = CurrentTile.Neighbours[randomKey];
                CurrentTile.HasBeenVisited = true;
            }
        });
    }

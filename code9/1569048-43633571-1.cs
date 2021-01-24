    void VisitAllNeighbours()
    {
        Task.Run(() =>
        {
            while (true)
            {
                bool bHasUnvisitedNeighbours = false;
                DispatcherOperation dispopunvisitedtiles = Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    bHasUnvisitedNeighbours = HasUnvisitedNeighbours();
                };
                dispopunvisitedtiles.Wait();
                if (!bHasUnvisitedNeighbours)
                    break;
                DispatcherOperation dispopvisitnext = Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    CurrentTile.Draw();
                    //1. Choose randomly a neighbour
                    List<char> Keys = new List<char>(CurrentTile.Neighbours.Keys);
                    randomKey = Keys[rnd.Next(Keys.Count)];
                    CurrentTile = CurrentTile.Neighbours[randomKey];
                    CurrentTile.HasBeenVisited = true;
                }));
                // Take out this "wait" if you want your "visits" to be
                // able to occur in parallel instead of only one at a time
                // - be careful that your "random visiting" selection code
                // doesn't cause too many "visits" to be outstanding though!
                dispopvisitnext.Wait();
                Thread.Sleep(500); // if you want a "delay" between each Tile visit
            );
        }
    }

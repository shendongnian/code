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
                // Take out this "wait" if you want multiple "visits" to be
                // pending/scheduled instead of only one at a time - be
                // careful that your "random visiting" selection code
                // doesn't cause too many "visits" to be outstanding though!
                //
                // Note: each visit never occurs at the same time as another
                // one as the "Dispatcher"/message loop is providing the
                // serialization.
                dispopvisitnext.Wait();
                Thread.Sleep(500); // if you want a "delay" between each Tile visit
            );
        }
    }

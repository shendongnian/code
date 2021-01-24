    while (true)
    {
        try
        {
            using (GameUnitOfWork unitOfWork = new GameUnitOfWork())
            {
                int currentUid = int.Parse(User.Identity.Name);
                Game game = unitOfWork.Games.GetActiveGameOfUser(currentUid);
                Player localPlayer = game.Players.First(p => p.User.Id == currentUid);
                localPlayer.FinishedExecutingTurn = true;
    
                if (game.Players.All(p => p.FinishedExecutingTurn))
                {
                    //do some stuff
                }
                unitOfWork.Commit();
            }
            return;
        }
        catch (GenericADOException ex)
        {
            // SQL-Server specific code for identifying deadlocks
            // Adapt according to your database errors.
            var sqlEx = ex.InnerException as SqlException;
            if (sqlEx == null || sqlEx.Number != 1205)
                throw;
            // Deadlock, just try again by letting the loop go on (eventually
            // log it).
            // Need to acquire a new session, previous one is dead, put some
            // code here for disposing your previous contextual session and 
            // put a new one instead.
        }
    }

    public abstract class GameInstanceCommandHandler<T>
        : CommandHandlerBase<T, GameInstanceIDCommandResult>
        where T : GameInstanceCommand
    {
        protected GameInstance GameInstance { get; private set; }
        protected GameInstanceCommandHandler() { }
        public GameInstanceCommandHandler(IUnitOfWork uow)
            : base(uow)
        {
        }
        public override GameInstanceIDCommandResult Execute(T command)
        {
            Check.Null(command, "command");
            try
            {
                AddCommandInstance(command.GameInstanceID);
            }
            catch(Exception ex)
            {
                return GetResult(false, "Only one command can be ran on an instance at a time.");
            }
            GameInstance = UnitOfWork.GameInstances.FirstOrDefault(p => p.ID == command.GameInstanceID);
            if (GameInstance == null)
            {
                RemoveCommandInstance(command.GameInstanceID);
                return GetResult(false, "Could not find game instance.");
            }
            if (GameInstance.IsComplete)
            {
                var completeResult = GetResult(GameInstance.ID);
                completeResult.Messages.Add("Game is complete, you cannot update the game state.");
                completeResult.Success = false;
                completeResult.IsGameComplete = true;
                RemoveCommandInstance(command.GameInstanceID);
                return completeResult;
            }
            UnitOfWork.LoadCollection(GameInstance, p => p.AppInstances);
            GameInstanceIDCommandResult result = null;
            try
            {
                result = ExecuteCommand(command);
                UnitOfWork.Save();
            }
            catch(Exception ex)
            {
                result = GetResult(false, ex.Message);
            }
            finally
            {
                RemoveCommandInstance(command.GameInstanceID);
            }
            return result;
        }
        private void AddCommandInstance(Guid gameInstanceID)
        {
            UnitOfWork.Add(new CommandInstance() { ID = gameInstanceID });
            UnitOfWork.Save();
        }
        private void RemoveCommandInstance(Guid gameInstanceID)
        {
            UnitOfWork.Remove(UnitOfWork.CommandInstances.First(p => p.ID == gameInstanceID));
            UnitOfWork.Save();
        }
        protected GameInstanceIDCommandResult GetResult(bool success, string message)
        {
            return new GameInstanceIDCommandResult(success, message);
        }
        protected GameInstanceIDCommandResult GetResult(Guid id)
        {
            return new GameInstanceIDCommandResult(id);
        }
        protected void LoadGameAndGameApps()
        {
            UnitOfWork.LoadReference(GameInstance, p => p.Game);
            UnitOfWork.LoadCollection(GameInstance.Game, p => p.GameApps);
        }
        protected abstract GameInstanceIDCommandResult ExecuteCommand(T command);
    }

        // from /a/40742144
        private static readonly List<string> _ignoredColumns = new List<string> { "StartTime", "EndTime" };
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            if (interceptionContext.OriginalResult.DataSpace == DataSpace.SSpace)
            {
                var insertCommand = interceptionContext.Result as DbInsertCommandTree;
                if (insertCommand != null)
                {
                    var newSetClauses = GenerateSetClauses(insertCommand.SetClauses);
                    var newCommand = new DbInsertCommandTree(
                        insertCommand.MetadataWorkspace,
                        insertCommand.DataSpace,
                        insertCommand.Target,
                        newSetClauses,
                        insertCommand.Returning);
                    interceptionContext.Result = newCommand;
                }
                var updateCommand = interceptionContext.Result as DbUpdateCommandTree;
                if (updateCommand != null)
                {
                    var newSetClauses = GenerateSetClauses(updateCommand.SetClauses);
                    var newCommand = new DbUpdateCommandTree(
                    updateCommand.MetadataWorkspace,
                    updateCommand.DataSpace,
                    updateCommand.Target,
                    updateCommand.Predicate,
                    newSetClauses,
                    updateCommand.Returning);
                    interceptionContext.Result = newCommand;
                }
            }
        }

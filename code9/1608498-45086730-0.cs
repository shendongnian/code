    class MyClass
    {
        private readonly Dictionary<string, Action<SQLLiteConnection>> _actions = new Dictionary<string, Action<SQLLiteConnection>>();
        public MyClass()
        {
            _actions.Add("Project", conn => conn.DropTable<Project>());
            _actions.Add("Task", conn => conn.DropTable<Task>());
        }
        public void ClearTable(string type)
        {
            try
            {
                using (var connection = new SQLiteConnection(platform, dbPath))
                {
                    var action = _actions[type](connection);
                    action(connection);
                }
            }
            catch (KeyNotFoundException ex1)
            { 
                Log.Info(String.Format("{0} is not a supported type.", type));
            }
            catch (SQLiteException ex2)
            {
                Log.Info("SQLiteEx", ex2.Message);
            }
        }
    }

        public bool CheckDependencyAutomationIsAwakeOnTable(string tableName)
        {
            string q = string.Format("SELECT [name] FROM sys.triggers WHERE [name] like 'tr_%_{0}_%'", tableName);
            var query = Session.CreateSQLQuery(q);
            query.SetResultTransformer(Transformers.AliasToBean<SQLTableDependecyCheck>());
            var list = query.List<SQLTableDependecyCheck>();
            return list.Count() == 1;
            
        }
        private class SQLTableDependecyCheck
        {
            public SQLTableDependecyCheck()
            {
            }
            public string name { get; set; }
        }

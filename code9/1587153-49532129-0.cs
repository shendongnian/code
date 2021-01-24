        public bool CheckDependencyAutomationIsAwakeOnTable(string tableName)
        {
            string q = string.Format("SELECT [name] FROM sys.triggers WHERE [name] like 'tr_%_{0}_%'", tableName);
            var query = Session.CreateSQLQuery(q);
            query.SetResultTransformer(Transformers.AliasToBean<string>());
            return query.List<string>().Count()==1;
            
        }

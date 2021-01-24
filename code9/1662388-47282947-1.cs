    public override void Visit(StatementList node)
    {
    	foreach (DeclareTableVariableStatement declareTableVariableStatement in node.Statements.Where(a => a is DeclareTableVariableStatement).ToList())
        {
            BeginEndBlockStatement deleteBeginEndBlockStatement = new BeginEndBlockStatement()
            {
                StatementList = new StatementList()
            };
    
            DeleteStatement deleteStatement = new DeleteStatement()
            {
                DeleteSpecification = new DeleteSpecification()
                {
                    Target = new VariableTableReference()
                    {
                        Variable = new VariableReference()
                        {
                            Name = declareTableVariableStatement.Body.VariableName.Value
                        }
                    }
                }
            };
    
            deleteBeginEndBlockStatement.StatementList.Statements.Add(deleteStatement);
            node.Statements.Insert(node.Statements.IndexOf(declareTableVariableStatement) + 1, deleteBeginEndBlockStatement);
        }
        base.Visit(node);
    }

    public class Interceptor : IDbCommandTreeInterceptor {
        private readonly int[] _clientIds;
        public Interceptor(int[] clientIds) {
            _clientIds = clientIds;
        }
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext) {            
            if (interceptionContext.Result.CommandTreeKind == DbCommandTreeKind.Query)
                InterceptQuery(interceptionContext);
        }
        private void InterceptQuery(DbCommandTreeInterceptionContext interceptionContext) {
            if (interceptionContext.Result.DataSpace != DataSpace.CSpace)
                return;
            var query = interceptionContext.Result as DbQueryCommandTree;
            if (query != null) {
                var modified = query.Query.Accept(new CustomInVisitor(_clientIds));
                interceptionContext.Result = new DbQueryCommandTree(query.MetadataWorkspace, query.DataSpace, modified);
            }
        }
        private class CustomInVisitor : DefaultExpressionVisitor {
            private readonly int[] _clientIds;
            public CustomInVisitor(int[] clientIds) {
                _clientIds = clientIds;
            }
            public override DbExpression Visit(DbScanExpression expression) {
                var table = (EntityType) expression.Target.ElementType;
                // obviously use another way to filter
                // here I just check if there is Clients navigation property
                var prop = table.NavigationProperties.FirstOrDefault(c => c.Name == "Clients");
                if (prop == null)
                    return expression;
                var binding = expression.Bind();
                // building x => x.Clients
                var propFilter = binding.VariableType
                    .Variable(binding.VariableName)
                    .Property(prop);
                // building list of DbConstantExpressions for In clause
                var list = _clientIds.Select(item => DbExpressionBuilder.Constant(item)).ToList();
                // building x => x.Clients.Any(client => clientIds.Contains(client.Id))
                var any = propFilter.Any(exp => exp.Property("Id").In(list));
                return binding.Filter(any);
            }
        }
    }

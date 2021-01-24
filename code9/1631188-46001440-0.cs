    var sortingColumn = "OrderProp";
    var binding = expression.Bind();
    return DbExpressionBuilder.Sort(binding,
                    new[] {
                        DbExpressionBuilder.ToSortClause(binding.VariableType.Variable(binding.VariableName).Property(sortingColumn) )
                    });

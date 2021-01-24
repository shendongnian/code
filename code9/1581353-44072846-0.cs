    foreach (var select in selectStatementVisitor.Statements)
            {
                var columnReferences = new ColumnReferenceExpressionVisitor();
                select.Accept(columnReferences);
                foreach (var item in (select.QueryExpression as QuerySpecification).SelectElements)
                {
    //other code here if you want ...
                    if (item is SelectScalarExpression)
                    {
                        var expression = item as SelectScalarExpression;
                        if (expression.Expression is ColumnReferenceExpression)
                        {
                            var column = expression.Expression as ColumnReferenceExpression;
                            Console.WriteLine(column); // <-- this is only ColumnReferenceExpression's
                        }
                    }
                }
            }

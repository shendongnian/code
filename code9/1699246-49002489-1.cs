    var p = Expression.Parameter(typeof(int), "p");
    Expression assignment = Expression.Assign(p, Expression.Constant(1));
    Expression addAssignment = Expression.AddAssign(p, Expression.Constant(5));
    BlockExpression addAssignmentBlock = Expression.Block(
    	new ParameterExpression[] { p },
    	assignment, addAssignment);
    
    SyntaxTree tree = addAssignmentBlock.ToSyntaxTree();

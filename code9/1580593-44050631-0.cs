    private static void MyMethod(Expression<Func<Model, bool>> parameters) {
        // body is "p.Age != 23"
        var current = parameters.Body;            
        var binary = current as BinaryExpression;
        if (binary == null)
            throw new Exception("Invalid expression");
        // left is "p.Age"
        var left = binary.Left as MemberExpression;
        // right is "23" (constant)
        var right = binary.Right as ConstantExpression;
        if (left != null && right != null) {
            // you can check if Member has Searchable attribute here
            var propertyName = left.Member.Name; // "Age"
            var op = binary.NodeType == ExpressionType.NotEqual ? "!=" : binary.NodeType == ExpressionType.Equal ? "=" : "etc..."; // "!="
            var value = right.Value; // 23
        }
    }

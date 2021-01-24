    private int HashFilter<T>( Expression<Func<T, bool>> filter ) {
      var param = filter.Parameters[0];
      var operation = filter.Body as BinaryExpression;
      var leftParameter = operation.Left as ParameterExpression;
      var leftIndex = operation.Left as MemberExpression;
      var type = operation.Left.GetType().FullName;
      var rightConstant = operation.Right as ConstantExpression;
      object result;
      if ( rightConstant == null ) {
        var rightMember = operation.Right as MemberExpression;
        result = Expression.Lambda( rightMember ).Compile().DynamicInvoke();
      }
      else {
        result = rightConstant.Value;
      }
      var value = result as string;
      var leftHashCode = leftParameter != null ? leftParameter.Name.GetStableHashCode() : leftIndex.Member.Name.GetStableHashCode();
      var operationHashCode = operation.NodeType.ToString().GetStableHashCode();
      unchecked {
        if ( value != null ) {
          return leftHashCode | operationHashCode | value.GetStableHashCode();
        }
        else {
          return leftHashCode | operationHashCode | result.GetHashCode();
        }
      }
    }

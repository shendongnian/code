    class AutoMapVisitor<TSource, TDestination>: ExpressionVisitor
    {
        // your stuff
		protected override Expression VisitBinary(BinaryExpression node)
		{
			var memberNode = IsBirthdayNode(node.Left)
				? node.Left
				: IsBirthdayNode(node.Right)
					? node.Right
					: null;
			if (memberNode != null)
			{
				var valueNode = memberNode == node.Left
					? node.Right
					: node.Left;
				// get the value
				var valueToChange = (int?)getValueFromNode(valueNode);
				var leftIsMember = memberNode == node.Left;
				var newValue = Expression.Constant(DataTypesExtensions.NullIntToNullDateTime(valueToChange, /*insert your format here */ ""));
				var newMember = Visit(memberNode);
				return Expression.MakeBinary(node.NodeType, leftIsMember ? newMember : newValue, leftIsMember ? newValue : newMember); // extend this if you have a special comparer or sg
			}
			return base.VisitBinary(node);
		}
		
		private bool IsBirthdayNode(Expression ex)
		{
			var memberEx = ex as MemberExpression;
			return memberEx != null && memberEx.Member.Name == "Birthday" && memberEx.Member.DeclaringType == typeof(PersonViewModel);
		}
		
		private object getValueFromNode(Expression ex)
		{
			var constant = ex as ConstantExpression;
			if (constant != null)
				return constant.Value;
			var cast = ex as UnaryExpression;
			if (cast != null && ex.NodeType == ExpressionType.Convert)
				return Convert.ChangeType(getValueFromNode(cast.Operand), cast.Type);
			// here you can add more shortcuts to improve the performance of the worst case scenario, which is:
			return Expression.Lambda(ex).Compile().DynamicInvoke(); // this will throw an exception, if you have references to other parameters in your ex
		}
		
	}

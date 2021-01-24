    public string GetName(Expression e, out Expression parent)
    {	
    	if(e is MemberExpression  m){ //property or field			
    		parent = m.Expression;
    		return m.Member.Name;
    	}
    	else if(e is MethodCallExpression mc){			
    		string args = string.Join(",", mc.Arguments.SelectMany(GetExpressionParts));
    		if(mc.Method.IsSpecialName){ //for indexers, not sure this is a safe check...			
    			return $"{GetName(mc.Object, out parent)}[{args}]";
    		}
    		else{ //other method calls		
    			parent = mc.Object;
    			return $"{mc.Method.Name}({args})";						
    		}
    	}
    	else if(e is ConstantExpression c){	//constant value
    		parent = null;
    		return c.Value?.ToString() ?? "null";		
    	}
    	else if(e is UnaryExpression u){ //convert
    		parent=  u.Operand;
    		return null;
    	}
    	else{
    		parent =null;
    		return e.ToString(); 
    	}
    }
    
    public IEnumerable<string> GetExpressionParts(Expression e){
    	var list = new List<string>();
    	while(e!=null && !(e is ParameterExpression)){
    		var name = GetName(e,out e);
    		if(name!=null)list.Add(name);
    	}
    	list.Reverse();
    	return list;
    }
    
    public string GetExpressionText<T>(Expression<Func<T, object>> expression) => string.Join(".", GetExpressionParts(expression.Body));

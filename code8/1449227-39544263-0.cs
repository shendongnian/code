    private static CodeAssignStatement setProp(string propName, object propValue, Type propType, Type objType)
    {
        CodeAssignStatement declareVariableName = null;
        declareVariableName = new CodeAssignStatement(
            new CodePropertyReferenceExpression(new CodeVariableReferenceExpression("testObj"), propName),
            new CodePrimitiveExpression(propValue)
        );
        return declareVariableName;
    }

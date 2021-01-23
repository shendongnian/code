    const string fieldName = "_d3";
    // Create the backing field for the property.
    var field = new CodeMemberField(typeof(string), fieldName);
    // Create the property.
    var prop = new CodeMemberProperty();
    prop.Attributes = MemberAttributes.Public | MemberAttributes.Final; // Public, non-virtual.
    prop.Name = "d3";
    prop.Type = new CodeTypeReference(typeof(string));
    prop.GetStatements.Add(new CodeMethodReturnStatement(new CodeVariableReferenceExpression(fieldName)));
    prop.SetStatements.Add(new CodeAssignStatement(new CodeVariableReferenceExpression(fieldName), new CodeVariableReferenceExpression("value")));
    // Create the attribute declaration for the property.
    var attr = new CodeAttributeDeclaration(new CodeTypeReference(typeof(System.ComponentModel.DataAnnotations.RangeAttribute)));
    attr.Arguments.Add(new CodeAttributeArgument(new CodeTypeOfExpression(typeof(decimal))));
    attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression("-922337203685477.5808")));
    attr.Arguments.Add(new CodeAttributeArgument(new CodePrimitiveExpression("922337203685477.5807")));
    attr.Arguments.Add(new CodeAttributeArgument("ErrorMessage", new CodePrimitiveExpression("")));
    prop.CustomAttributes.Add(attr);
    // Create a class to contain the property.
    var testClass = new CodeTypeDeclaration("TestClass");
    testClass.Members.Add(field);   // Add the backing field.
    testClass.Members.Add(prop);    // Add the property.

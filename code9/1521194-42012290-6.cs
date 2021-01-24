    // From reflection
    var nameA = typeof(DtoDerived).GetMember(nameof(DtoDerived.Name)).Single();
    // Same as
    //var nameA = typeof(DtoDerived).GetProperty(nameof(DtoDerived.Name));
    
    // From compile time expression
    Expression<Func<DtoDerived, NameDtoType>> compileTimeExpr = _ => _.Name;
    var nameB = ((MemberExpression)compileTimeExpr.Body).Member;
    
    // From runtime expression
    var runTimeExpr = Expression.PropertyOrField(Expression.Parameter(typeof(DtoDerived)), nameof(DtoDerived.Name));
    var nameC = runTimeExpr.Member;
    
    Assert.AreEqual(nameA, nameC); // Success
    Assert.AreEqual(nameA, nameB); // Fail

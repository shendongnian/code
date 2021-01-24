    public Action<T> BuildAssignments<T>(Expression instance, IEnumerable<MemberExpression> propertiesAffected) where T : class {
    List<Expression> operations = new List<Expression>();
    foreach (var pr in propertiesAffected) {
                                  int num;
                                  string extract = RegEx.Match(pr.Name, "(\d+)$").Value;
                                  if (!string.IsNullOrWhitespace(extract)) {
                                     num = Int.Parse(extract);
              // This is to wrap the calculated value as a constant value                       
              var target = Expression.Constant($"{picturepath}{num}.png");
                                  // Assign the property access of BackgroundPicture from pr (so the idea of instance.bt1.BackgroundPicture) to the templated value constructed
                  
                  
                 operations.Add(Expression.Assign(Expression.PropertyOrField(pr, "BackgroundPicture"), target));
                                  }
                                 }
                                 
                                 return Expression.Lambda<Action<ExampleClass>>(operations, instance).Compile();
                         }

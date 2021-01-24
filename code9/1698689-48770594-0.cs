    private static bool IsNullExpression(Expression exp)
    {
        // If types are different  for example int and int? there will be an extra conversion expression, we need to unwrap this
        if (exp is UnaryExpression uExp) exp = uExp.Operand;
        // If we are dealing with a captured variable, then teh constant will be the capture object and the value is stored as a member on this object
        if (exp is MemberExpression mExp && mExp.Expression is ConstantExpression cExp)
        {
            object value = mExp.Member is PropertyInfo pInfo ? pInfo.GetValue(cExp.Value) :
                mExp.Member is FieldInfo fInfo ? fInfo.GetValue(cExp.Value) :
                throw new NotSupportedException();
            return value == null;
        }
        // If we use a simple constant, this is what will be called
        if (exp is ConstantExpression constantExpression)
        {
            return constantExpression.Value == null;
        }
        return false;
    }
    // Tested with the following
    // Simple constant expressions
    TestMethod(p => p.Id == 0);
    TestMethod(p => p.Id == null);
    // Capture a non null value 
    int value = 0;
    TestMethod(p => p.Id == value);
    // Capture a null value 
    int? nullValue = null;
    TestMethod(p => p.Parent.Id == nullValue);
    // Testing infrastructure
    public static bool TestMethod(Expression<Func<Person, bool>> exp)
    {
        // If we have a binary expression
        if (exp.Body is BinaryExpression binaryExpression && (IsNullExpression(binaryExpression.Left) || IsNullExpression(binaryExpression.Right)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public class Person
    {
        public int? Id { get; set; }
    }

    static Expression<Func<Customer, bool>> ExpressionBuilder(string phrase) {
        //We are trying to set up the equivalent of this:
        //  x => x.PersonMail == phrase || x.BusinessMail == phrase || x.ContanctName == ...
        //The lambda expression has a single parameter
        //  x =>
        //In the body of the lambda, for each string property on Customer, we want to call the 
        //property on the parameter, and then check if it is equal to the phrase
        //  x.PersonMail == phrase
        //We then want to combine each result into an ||
        //  x.PersonMail == phrase || x.BusinessMail == phrase ...
    
        //Define an expression representing the parameter
        var prm = Parameter(typeof(Customer));
        //Get all the string properties
        var stringProps = typeof(Customer).GetProperties()
            .Where(x => x.PropertyType == typeof(string))
            //For each property, create an expression that represents reading the property, and 
            //comparing it to phrase as a constant (as if we had written the literal value into 
            //the query)
            .Select(x => Equal(MakeMemberAccess(prm, x), Constant(phrase)));
        //Combine the equals expressions using ||
        Expression expr = stringProps.Aggregate((prev, x) => Or(prev, x));
        //Wrap the body in a lambda expression of the appropriate type
        return Lambda<Func<Customer, bool>>(expr, prm);
    }

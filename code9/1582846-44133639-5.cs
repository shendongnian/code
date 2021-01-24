    public TResult Execute<TResult>(Expression expression)
    {
        IQueryable<Word> allSonnetWords = this.GetAllSonnetWords();
        var sequenceRequested = typeof(TResult).Name == "IEnumerable`1";
        // replace the expression for a WordCollection to an expression for IQueryable<Word>
        var expressionModifier = new ExpressionTreeModifier(allSonnetWords);
        Expression modifiedExpression = expressionModifier.Visit(expression);
        TResult result;
        if (isEnumerable)
            // A sequence is requested. Return a query on allSonnetWords provider
            result = (TResult)allSonnetWords.Provider.CreateQuery(modifiedExpression);
        else
            // a single element is requested. Execute the query on the allSonnetWords.provider
                result = (TResult)allSonnetWords.Provider.Execute(modifiedExpression);
        return result;
    }

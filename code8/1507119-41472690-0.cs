    public static class QueryableExtensions
    {
    	public static IQueryable<SelectorViewModel> ToSelectorViewModel<T>(
    		this IQueryable<T> source, 
    		Expression<Func<T, long>> idSelector,
    		Expression<Func<T, string>> descriptionSelector,
    		Expression<Func<T, string>> codeSelector
    	)
    	{
    		Expression<Func<long, string, string, SelectorViewModel>> prototype =
    			(id, description, code) => new SelectorViewModel { Id = id, Description = description, Code = code };
    		var parameter = Expression.Parameter(typeof(T), "e");
    		var body = prototype.Body
    			.ReplaceParameter(prototype.Parameters[0], idSelector.Body.ReplaceParameter(idSelector.Parameters[0], parameter))
    			.ReplaceParameter(prototype.Parameters[1], descriptionSelector.Body.ReplaceParameter(descriptionSelector.Parameters[0], parameter))
    			.ReplaceParameter(prototype.Parameters[2], codeSelector.Body.ReplaceParameter(codeSelector.Parameters[0], parameter));
    		var selector = Expression.Lambda<Func<T, SelectorViewModel>>(body, parameter);
    		return source.Select(selector);
    	}
    }

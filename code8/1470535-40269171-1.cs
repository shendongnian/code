    public T GetRepository<T>() where T : class
    {
        var result = _componentContext.Resolve<T>(new NamedParameter("context", _context));
        if (result != null && result.GetType().GetInterfaces().Contains(typeof(ICompanyRepository)))
        {
            return result;
        }
        return null;   
    }

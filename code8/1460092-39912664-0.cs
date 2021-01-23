    private IQueryable<TReportClass> ApplyFilter(ReportFilter filter, IQueryable<TReportClass> baseQuery)
    {
        var property = typeof(TReportClass).GetProperty(filterMember);
        bool isCollection = property.Type != typeof(string) &&
            && typeof(IEnumerable).IsAssignableFrom(property.Type);
        Func<string, string, string> condtion;
        if (isCollection)
            condition = (format, member) => string.Format("{0}.Any({1})", member, string.Format(format, "it"));
        else
            condition = (format, member) => string.Format(format, member);
        switch (filter.Operator)
        {
            case ReportFilter.Operators.Contains:
                baseQuery = baseQuery.Where(condition("{0}.Contains(@0)", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.DoesNotContain:
                baseQuery = baseQuery.Where(condition("!{0}.Contains(@0)", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.IsEqualTo:
                baseQuery = baseQuery.Where(condition("{0} = @0", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.IsNotEqualTo:
                baseQuery = baseQuery.Where(condition("{0} != @0", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.StartsWith:
                baseQuery = baseQuery.Where(condition("{0}.StartsWith(@0)", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.EndsWith:
                baseQuery = baseQuery.Where(condition("{0}.EndsWith(@0)", filter.Member), filter.Value);
                break;
            case ReportFilter.Operators.IsNull:
                baseQuery = baseQuery.Where(condition("{0} = NULL", filter.Member));
                break;
            case ReportFilter.Operators.IsNotNull:
                baseQuery = baseQuery.Where(condition("{0} != NULL", filter.Member));
                break;
            case ReportFilter.Operators.IsEmpty:
                baseQuery = baseQuery.Where(condition("string.IsNullOrEmpty({0})", filter.Member));
                break;
            case ReportFilter.Operators.IsNotEmpty:
                baseQuery = baseQuery.Where(condition("!string.IsNullOrEmpty({0})", filter.Member));
                break;
        }
        return baseQuery;
    } 

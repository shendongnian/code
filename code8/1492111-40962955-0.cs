    public IEnumerable<LookUpValues> GetValuesByCode(string cd)
    {
        var query = from code in _context.LookUpCodes
                    join values in _context.LookUpValues 
                    on code.CodeId equals values.CodeId
                    where code.Code == cd
                    select values;
        return query;
    }

    Expression<Func<DenormalizedType, bool>> FilterBySelection(Selection selection)
    {
        switch(selection)
        {
            case Selection.Active:
                return x => x.IsActive == true;
            case Selection.InActive:
                return x => x.IsActive == false;
            case Selection.SomeOtherSelection:
                return x => x.SomeOther == "Criteria"
            default:
                return x => true;
        }
    }

    var childRecords = childRecordObject as IEnumerable; // IList<T> will be IEnumerable
    if (null != childRecords && childRecords.OfType<BaseDataEntity>().Any(x => x.HasDataChanged))
    {
        isChanged = true;
    }

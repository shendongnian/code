    public virtual object this[int index] {
        get {
            if (index < 0 || index >= InnerArray.GetCount(0)) {
                throw new ArgumentOutOfRangeException("index", SR.GetString(SR.InvalidArgument, "index", (index).ToString(CultureInfo.CurrentCulture)));
            }
     
            return InnerArray.GetItem(index, 0);
        }
        set {
            owner.CheckNoDataSource();
            SetItemInternal(index, value);
        }
    }

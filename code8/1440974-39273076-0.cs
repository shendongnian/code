    bool isViewNameInvalid;
    if (id.HasValue)
    {
        isViewNameInvalid = db.View.Any(v => v.ViewName == viewName && v.Id != id);
    }
    else
    {
        isViewNameInvalid = db.View.Any(v => v.ViewName == ViewName);
    }

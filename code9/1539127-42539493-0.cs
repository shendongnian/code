    Expression<Func<Parent, bool>> parentIsReady = ParentCriteria.IsReady();
    var readyParents = db.Parents.Where(parentIsReady);
    var childrenWithReadyParents = db.Children.AsExpandable()
       .Where(c => parentIsReady.Invoke(c.Parent))
       .Where(c => c.Value == "Foobar");

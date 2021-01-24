    Expression<Func<Entity, string>> orderByExpression = r => cqh.Contains(r.QuestionID) ? dict[(int)Math.Floor(r.SearchKey1)] + "2" + Guid.NewGuid() :
            iqh.Contains(r.QuestionID) ? dict[(int)Math.Floor(r.SearchKey1)] + "1" + Guid.NewGuid() :
            dict[(int)Math.Floor(r.SearchKey1)] + "0" + Guid.NewGuid();
    var replace = (Expression<Func<Entity, string>>)new DictionaryReplaceVisitor().Visit(orderByExpression);
    var query = db.Entity.OrderBy(replace).ToString();

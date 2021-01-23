    public class myClass {
      public virtual int count { get; set; }
      public virtual İnt catId { get; set; }
      public virtual cat cats { get; set; }
    }
    cat cats = null;
    answer answers = null;
    
    var u = db.QueryOver<cat>(() => cats)
        .JoinQueryOver(x => x.answers, () => answers, NHibernate.SqlCommand.JoinType.LeftOuterJoin, Restrictions.Eq("answers.stat", false))
        .SelectList(cv => cv
            .SelectCount(() => answers.id)
            .SelectGroup(c => c.id))
        .List<object[]>()
        .Select(ax => new myClass
        {
          count = (int)ax[0],
          catId = (int)ax[1],
          cats = (cat)db.QueryOver<cat>().Where(w=>w.id==(int)ax[1]).SingleOrDefault()
        })
        .ToList();

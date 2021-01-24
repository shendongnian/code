    public class MyThing {
       public string ID {get;set;}
       public string ID_REG {get;set;}
       public decimal SIG {get;set;}
    }
    protected IQueryable<MyThing> method()
    {
        return (from a in BAS1
                 join b in BAS2 on a.TIP equals b.TIP 
                 join c in BAS3 on a.COM equals c.COM 
                 join d in BAS4 on c.PROV equals d.PROV 
                 join e in BAS5 on d.ID_REG equals e.ID_REG
                 select new MyThing
                 {
                     a.ID,
                     b.SIG,
                     e.ID_REG,
                 });
    }

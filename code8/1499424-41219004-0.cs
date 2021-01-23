    public class MyModel {
       public List<Company> Companies {get;set;}
       public List<Contractor> Contractors {get;set; }
    }
___
    var all_companies = db_cnx.Db.tbl_company.ToList();
    var all_contractors = db_cnx.Db.tbl_contractor.toList();
    var model = new MyModel {
        Companies = all_companies,
        Contractos = all_contractors
    }
    
    return View(model);

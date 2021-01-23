            Init Initobj = new Init 
            {
                Id = Id ,
                DocId= DocId,
                SupplierText=SupplierText
                //other properties
            };
            db.Init.Add(Initobj);    
            db.SaveChanges();
            Form formobj = new Form
            {
                initID= Initobj.Id,
                
            };
            db.forms.Add(formobj);    
            db.SaveChanges();
    

    var GridData = (from a in Global.AcepakSalesPortal.Enquiries
                       join Cust in Global.AcepakSalesPortal.Customers
                           on a.CustomerID equals Cust.CustomerID into CustGroup
                       from b in CustGroup.DefaultIfEmpty()
                       join Pros in Global.AcepakSalesPortal.Prospects
                           on a.ProspectID equals Pros.ProspectID into ProsGroup
                       from c in ProsGroup.DefaultIfEmpty()
                       join Users in Global.AcepakSalesPortal.Users
                           on a.ResponsiblePartyID equals Users.UserID into UserGroup
                       from d in UserGroup.DefaultIfEmpty()
                       join Qt in Global.AcepakSalesPortal.Quotes
                           on a.QuoteID equals Qt.QuoteID into QuoteGroup
                       from e in QuoteGroup.DefaultIfEmpty()
                       join Usr in Global.AcepakSalesPortal.Users
                           on e.CreatedBy equals Usr.UserID into UsrGroup
                       from f in UsrGroup.DefaultIfEmpty()
                       join EnqCat in Global.AcepakSalesPortal.EnquiryCategories
                           on a.EnquiryCategoriesID equals EnqCat.EnquiryCatID into CatGroup
                       from g in CatGroup.DefaultIfEmpty()
                       join Clsd in Global.AcepakSalesPortal.Users
                           on a.ClosedBy equals Clsd.UserID into ClsdGroup
                       from h in ClsdGroup.DefaultIfEmpty()
                       orderby a.Created descending
                       select a).ToList()

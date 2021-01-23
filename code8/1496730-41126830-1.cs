       public void DeleteContents(List<int> entityIds)
       {
            using (Yourcontext db = new Yourcontext())
            {
                IQueryable<ContentTable> contents = db.ContentTable.Where((x) => ids.Contains(x.EntityId));
    
                db.ProductComplianceRules.DeleteAllOnSubmit(contents);
            }
       }

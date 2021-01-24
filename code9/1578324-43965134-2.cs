    List<EF_Model.PDF> Customers_File(int _id) {
        using (var Context = new EF_Model.CoolerEntities()) {
            var q = from c in Context.PCs
                    join p in Context.PDFs on c.Ref_PDF equals p.Id
                    where c.Ref_Customer == _id
                    select new EF_Model.PDF { Id = c.PDF.Id, Name = c.PDF.Name, File = c.PDF.File };
            return q.ToList();
        }
    }

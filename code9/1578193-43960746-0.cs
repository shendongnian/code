    internal EF_Model.PDF Search_PDF(string _name)
    {
        using (var Context = new EF_Model.CoolerEntities())
        {
            return Context.PDFs.FirstOrDefault(c => c.Name == _name);
        }
    }
   

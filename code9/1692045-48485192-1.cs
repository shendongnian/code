    public class MyViewModel
    {
        public string Heading { get;set; }
        public int ID { get; set; }
    }
    public static class MyViewModelsExtensions
    {
        public static IQueryable<ListViewModel> ToEbookViewModels(this IQueryable<ClassEbook> classEBooks)
        {
            return classEBooks.Select(m => new ListViewModel { Heading = m.Heading, ID = m.ClassEbookID });
        }
        // TDOD: Add other ToViewModels methods to handle tranforming ClassNote and ClassSamplePaper models
    }
    // Inside controller action/where your current switch statement is
    switch (dbundle.MaterialIndicator)
    {
             case 1:
                    var EBookList = (from cl in db.ClsObj......);
                    List<ListViewModel> viewModelEbook = EBookList.ToEbookViewModels().Distinct().ToList();
                    return new JsonResult { Data = viewModelEbook, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            case 2:
            case 3:
                // both of these will look similar to the above case handling except you will pass in IQueryable of ClassNote and ClassSamplePaper
    }

    public class MyViewModel
    {
        public string Heading { get;set; }
        public int ID { get; set; }
    }
    public static class MyViewModelsExtensions
    {
        public static IQueryable<MyViewModel> ToViewModels(this IQueryable<ClassEbook> classEBooks)
        {
            return classEBooks.Select(m => new MyViewModel
            {
                Heading = m.Heading;
                ID = m.ID;
            });
        }
        // TDOD: Add other ToViewModels methods to handle tranforming ClassNote and ClassSamplePaper models
    }
    // Inside controller action/where your current switch statement is
    switch (dbundle.MaterialIndicator)
    {
            case 1:
                List<ClassEBook> eBookList = (from cls....); // Remove the .ToList() call because we want an IQueryable
                List<MyViewModel> viewModels = eBookList.ToViewModels().ToList();
                return new JsonResult { Data = viewModels, JsonRequestBehavior.... };
            case 2:
            case 3:
                // both of these will look similar to the above case handling except you will pass in IQueryable of ClassNote and ClassSamplePaper
    }

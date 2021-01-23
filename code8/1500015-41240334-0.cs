    public class UIclass
    {
        private readonly IReportFactory _reportFactory;
        public UIclass(IReportFactory reportFactory)
        {
            _reportFactory = reportFactory;
        }
        private static string GetDocumentIntoJson(int clientId, int pager)
        {
            // Use factory to get a ReportHandler
            // You need provide "factoryId" from somewhere too
            IReportHandler dal = _reportFactory.Create(factoryId);
            var documents = dal.FetchDocumentsList(clientId, pager);
            string documentsDataJSON = JsonConvert.SerializeObject(documents);
            return documentsDataJSON;
        }
    }

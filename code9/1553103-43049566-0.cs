    public class AOService<TAnalysisObject> where TAnalysisObject : AnalysisObject, new()
    {
        public AnalysisObject FetchObject(int id)
        {
            return new TAnalysisObject();
        }
    }

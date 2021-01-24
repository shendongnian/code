    public class POST
    {
        public IRestResponse Create<T>(RestClient Client, T Resource, string Path)
        {
            IRestResponse Resp = null;
            RestRequest Req = Configuration.ConfigurePostRequest(Path);
            foreach (var property in Resource.GetType().GetProperties())
            {
                Req.AddParameter(String.Format("{0}[{1}]", Resource.GetType().Name.ToString().ToLower(), property.Name), Resource.GetType().GetProperty(property.Name).GetValue(Resource, null));
            }
            return Resp;
        }
    }

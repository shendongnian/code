    public class jsonStorage
    {
        // your properties here
        ...
        ...
        // override the ToString
        public override string ToString()
        {
            return "userid=" + userId + Environment.NewLine +
                   "id=" + id + Environment.NewLine +
                   "title=" + title + Environment.NewLine +
                   "body=" + body;
        }
    }

    public class MyMultipartContent : MultipartContent
    {
        public override void Add(HttpContent content)
        {
            base.Add(content);
            foreach (var header in content.Headers.ToList())
            {
                if (!this.Headers.Contains(header.Key))
                    this.Headers.Add(header.Key, header.Value);
            }
        }
    }

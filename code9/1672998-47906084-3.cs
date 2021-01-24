    public class TransformCordinator
    {
        Dictionary<int, Action<Template>> transformMap = new Dictionary<int, Action<Template>>();
        public TransformCordinator()
        {
            transformMap.Add(1, x => new Transform1().Do(x));
            transformMap.Add(2, x => new Transform2().Do(x));
        }
        public void Do(Template template)
        {
            transformMap[template.TransformNo](template);
        }
    }

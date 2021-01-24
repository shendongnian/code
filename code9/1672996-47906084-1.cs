    public class Transform1 : ITransform
    {
        public void Do(Template template)
        {
            Console.WriteLine($"Transform : {template.TransformNo}, TemplateTitle : { template.Title}");
        }
    }

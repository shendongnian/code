    public class Transform2 : ITransform
    {
        public void Do(Template template)
        {
            Console.WriteLine($"Transform : {template.TransformNo}, TemplateTitle : { template.Title}");
        }
    }

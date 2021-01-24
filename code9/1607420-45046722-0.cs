    public class CustomBootStrapper : DefaultNancyBootstrapper
        {
            protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
            {
                Nancy.Json.JsonSettings.MaxJsonLength = int.MaxValue;
                Nancy.Json.JsonSettings.MaxRecursions = 100;
                Nancy.Json.JsonSettings.RetainCasing = true;
                base.ApplicationStartup(container, pipelines);
            }
        }

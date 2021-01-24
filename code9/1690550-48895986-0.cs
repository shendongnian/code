    static public void Register(HttpConfiguration config)
    {
        config.MapHttpAttributeRoutes();
        var builder = new ODataConventionModelBuilder();
        if (IsModule1Enabled)
        {
            builder.EntitySet<Module1Entity>("Module1Entities");
        {
        if (IsModule2Enabled)
        {
           builder.EntitySet<Module2Entity>("Module2Entities");
        }
        var conventions = ODataRoutingConventions.CreateDefault();
        conventions.Insert(0, new MyAttributeRoutingConvention("odata", config));
        config.MapODataServiceRoute("odata", "api", builder.GetEdmModel(), new DefaultODataPathHandler(), conventions);
    }
    public class MyAttributeRoutingConvention : AttributeRoutingConvention
    {
        public MyAttributeRoutingConvention(string routeName, HttpConfiguration configuration) : base(routeName, configuration)
        {
        }
        public override bool ShouldMapController(HttpControllerDescriptor controller)
        {
           if (controller.ControllerType == typeof(Module1EntitiesController))
           {
              return IsModule1Enabled;
           }
           if (controller.ControllerType == typeof(Module2EntitiesController))
           {
              return IsModule2Enabled;
           }
           return base.ShouldMapController(controller);
        }
     }
    protected void Application_Start(object sender, EventArgs e)
    {
        GlobalConfiguration.Configure(Register);
    }

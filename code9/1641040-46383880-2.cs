    public static RazorViewEngineOptions AddCloudscribeSimpleContentBootstrap3Views(this RazorViewEngineOptions options)
    {
        options.FileProviders.Add(new EmbeddedFileProvider(
                    typeof(Bootstrap3).GetTypeInfo().Assembly,
                    "cloudscribe.SimpleContent.Web.Views.Bootstrap3"
              ));
        return options;
    } 

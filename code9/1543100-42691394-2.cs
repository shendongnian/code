    private static HelpPageApiModel GenerateApiModel(ApiDescription apiDescription, HttpConfiguration config)
    {
       HelpPageApiModel apiModel = new HelpPageApiModel()
       {
          ApiDescription = apiDescription,
       };
    ModelDescriptionGenerator modelGenerator = config.GetModelDescriptionGenerator();
    HelpPageSampleGenerator sampleGenerator = config.GetHelpPageSampleGenerator();            
    GenerateUriParameters(apiModel, modelGenerator);
            
    // add this part
    var attrs = apiDescription.ActionDescriptor.GetCustomAttributes<DynamicUriParameterAttribute>();
    foreach (var attr in attrs)
    {
        apiModel.UriParameters.Add(
           new ParameterDescription
           {
               Name = attr.Name,
               Documentation = attr.Description,
               TypeDescription = modelGenerator.GetOrCreateModelDescription(attr.Type)
           }
         );
      }
      // until here
      GenerateRequestModelDescription(apiModel, modelGenerator, sampleGenerator);
      GenerateResourceDescription(apiModel, modelGenerator);
      GenerateSamples(apiModel, sampleGenerator);
      return apiModel;
    }

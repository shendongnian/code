    const string ResourceId = "$rootnamespace$.AppResources";
    var resmgr = new ResourceManager(ResourceId,typeof(TranslateExtension).GetTypeInfo().Assembly));        
    var ci = CrossMultilingual.Current.CurrentCultureInfo;
    Label selectLabel = new Label
    {
      Text = resmgr.GetString("SelectLanguage",ci),
      TextColor = Color.Black
    };
   

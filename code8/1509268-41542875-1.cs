     private bool ViewExists(string name)
     {
         ViewEngineResult result = ViewEngines.Engines.FindView(ControllerContext, name, null);
         return (result.View != null);
     }

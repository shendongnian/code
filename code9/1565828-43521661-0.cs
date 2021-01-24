    protected void Application_Start(object sender, EventArgs e)
    {
            Telerik.Sitefinity.Abstractions.Bootstrapper.Initialized += Bootstrapper_Initialized;
    }
    protected void Bootstrapper_Initialized(object sender, Telerik.Sitefinity.Data.ExecutedEventArgs args)
    {
            if (args.CommandName == "Bootstrapped") {
                EventHub.Subscribe<IPagePreRenderCompleteEvent>(this.OnPagePreRenderCompleteEventHandler);
            }
    }
    private void OnPagePreRenderCompleteEventHandler(IPagePreRenderCompleteEvent evt)
    {
            if (!evt.PageSiteNode.IsBackend)
            {
                var controls = evt.Page.Header.Controls;
                System.Web.UI.Control generatorControl = null; 
                for(int i=0;i< evt.Page.Header.Controls.Count;i++)
                {
                    var control = evt.Page.Header.Controls[i];
                    if ((control is HtmlMeta) && (control as HtmlMeta).Name == "Generator") {
                        generatorControl = control;
                    }
                }
                evt.Page.Header.Controls.Remove(generatorControl);
            }
     }

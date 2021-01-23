    try
    {
        var opts = new GenerateTokenOptions();
        opts.TokenAuthenticationType = TokenAuthenticationType.ArcGISToken;
        // generate an ArcGIS token credential with a hard-coded user name and password
        // (if authentication fails, an ArcGISWebException will be thrown)
        var cred = await IdentityManager.Current.GenerateCredentialAsync(
                                     "http://serverapps10.esri.com/arcgis/rest/services/", 
                                     "user1", 
                                     "pass.word1", 
                                     opts);
        // add the credential to the IdentityManager (will be included in all requests to this portal)
        IdentityManager.Current.AddCredential(cred);
        // load a layer based on a secured resource on the portal
        var layer = new ArcGISDynamicMapServiceLayer(new Uri
                            ("http://serverapps10.esri.com/arcgis/rest/services/GulfLawrenceSecureUser1/MapServer"));
        await layer.InitializeAsync();
        // add the layer to the map and zoom to its extent
        this.MyMapView.Map.Layers.Add(layer);
        await this.MyMapView.SetViewAsync(layer.FullExtent);
    }
    catch (ArcGISWebException webExp)
    {
        MessageBox.Show("Unable to authenticate with portal: " + webExp.Message);
    }
    catch (Exception exp)
    {
        MessageBox.Show("Unable to load secured layer: " + exp.Message);
    }

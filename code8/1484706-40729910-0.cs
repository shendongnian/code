    using Moq;
    using TransformRequest = Mycompany.Enterprise.Reporting.ServiceReferences.CssTransformation.TransformRequest;
    
    private MemoryStream _toReturn;
    
    public void SetupTest()
    {
        this._toReturn = new MemoryStream();    
    }
    public void TearDownTest()
    {
        if (this._toReturn != null)
        {
            this._toReturn.Dispose();
        }
    }
    
    public void YourTestMethod()
    {
        var client = new Mock<CSSFormTransformationClient>();
    
        client.Setup(c => c.TransformToPDF(It.IsAny<TransformRequest>())
              .Returns(this._toReturn);
        
        MemoryStream stream = client.TransformToPDF(cssRequest); //Get cssRequest beforehand... I don't know where it came from.
        //Continue with your test.
    }

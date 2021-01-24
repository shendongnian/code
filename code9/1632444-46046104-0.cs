    [HttpGet]
    [Route("integracao/iniciar")]
    public async Task<IHttpActionResult> FazerIntegrar()
    {
        try
        {
            Integrar objIntegrar = new Integrar();
    
            return Ok(await objIntegrar.Integra());
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    
    }

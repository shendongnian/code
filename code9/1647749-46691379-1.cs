	[HttpGet]
	[Authorize]
	[Route("monedas")]
	public IHttpActionResult GetMonedas(string empresaId, string filtro = "")
	{
		IEnumeradorService sectoresService = new MonedasService(empresaId);
		if (!initialValidation.EmpresaPerteneceACliente(empresaId, User))
		{
			return Content(HttpStatusCode.MethodNotAllowed, "La empresa no existe o el cliente no tiene acceso a ella");
		}
		return Ok(sectoresService.Enumerar(filtro));
	}
	[HttpGet]
	[Authorize]
	[Route("paises")]
	public IHttpActionResult GetPaises(string empresaId, string filtro = "")
	{
		IEnumeradorService sectoresService = new PaisesService(empresaId);
		if (!initialValidation.EmpresaPerteneceACliente(empresaId, User))
		{
			return Content(HttpStatusCode.MethodNotAllowed, "La empresa no existe o el cliente no tiene acceso a ella");
		}
		return Ok(sectoresService.Enumerar(filtro));
	}

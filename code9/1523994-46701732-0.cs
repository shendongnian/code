	/// <summary>
	/// Returns all objects
	/// </summary>
	/// <param name="request"></param>
	/// <returns></returns>
	[Route("")]
	[ResponseType(typeof(IEnumerable<ObjectResponse>))]
	public async Task<IHttpActionResult> GetObjects([FromUri] ObjectsGetRequest request) => 
      Ok(await this.mediator.Send(request ?? new ObjectsGetRequest()));

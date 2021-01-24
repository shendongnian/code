    [ResponseType(typeof (ListasPicking))]
    [HttpPut]
    public  IHttpActionResult PutLista ([FromBody] ListasPicking novaLista) {
        if(!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
        primContext.ListasPickingGet.Add(novaLista);
        primContext.SaveChanges();
        return StatusCode(HttpStatusCode.Created);
    }

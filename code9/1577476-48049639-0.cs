        [Route("GetAll")]
        [HttpPost]
         ...here your security directives
           **example**
        [AllowAnonymous]
         public JsonResult GetAll([FromBody]MupdateDto data)
        {
           try
            {
              List<MupdateDto > result = Service.GetAll(data);       
                return Json(response);
            }
            catch (Exception ex)
            {
                response.GenerateResponse(TransData.ResponseKo(ex.Message, -69), null, null);
                throw;
            }
        }

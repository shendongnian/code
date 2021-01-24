    public JsonResult GravarAvaliacao(bool avalia1, string idgravacao)
        {
          string _userId = User.Identity.GetUserId();
          var avaliaData = new OperadorAvaliacaoData();
          avaliaData.GravaAvaliacao(avalia1, idgravacao);
    
          return Json(true, JsonRequestBehavior.AllowGet);
        }

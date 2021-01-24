     public ActionResult AsignarCotizaciones(string id)
        {
           // YOUR LOGIC FOR EXAMPLE
            var model = _repository.FindAll(u => u.Id == id)
            return PartialView(model );
        }

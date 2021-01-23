    public ActionResult EnviarMensajeIndividual(MensajesEntity model)
        {
            InformacionEntity Info = new InformacionEntity();
            Info.error = false;
            model.usuarioCreacion = User.Identity.Name;
            if (HttpContext.Session["Lista"] != null && model.mensaje != null)
            {
                List<ContactoEntity> lista = HttpContext.Session["Lista"] as List<ContactoEntity>;
                int idTransaccion = mdm.EnviarMensajes(model, lista, 1);
                if (idTransaccion > 0)
                {
                    Info = mdm.InformacionDeEnvio(idTransaccion);
                    Info.error = false;
                }
                else
                {
                    //error
                    Info.error = true;
                    Info.mensajeError = "error.";
                }
            }
            else
            {
                // tiene q tener contactos agregados
                Info.error = true;
                Info.mensajeError = "error";
            }
            return View(Info);
        }

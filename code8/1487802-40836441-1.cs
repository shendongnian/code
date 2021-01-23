        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Rate()
        {
            return View(GetNewModel());
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Rate(usuarioConectado model)
        {
            ///
            /// When the user posts the form,
            /// the model parameter will have all
            /// of the values set in the 'get' method,
            /// along with the items selected.
            ///
            SaveModel(model);
            return View(GetNewModel());
        }
        private usuarioConectado GetNewModel()
        {
            return new usuarioConectado()
            {
                recetastbl_id_list = new List<string>() { "1", "2", "3" },
                usuariostbl_id_list = new List<string>() { "4", "5", "6" },
                valoracion = new List<string>() { "7", "8", "9" },
                username = "usuario1",
                usuariostbl_id = "1",
            };
        }
        private void SaveModel(usuarioConectado model)
        {
            //Save Stuff
        }

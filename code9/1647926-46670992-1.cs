            [HttpPost]
            public ActionResult Edit(List<int> code, List<string> titulo, List<string> genero)
            {
                if (code != null)
                { 
                for (int i = 0; i < Cartelera.Count; i++)
                {
                    if (code.Contains(i))
                    {
                        Cartelera[i].Titulo = titulo[i];
                        Cartelera[i].Genero = genero[i];
                    }
                }
                }
                return View("List1", Cartelera);
             }

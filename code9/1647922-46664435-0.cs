     [HttpGet]
        public ActionResult Edit()
        {
            List<Peliculas> list = new List<Peliculas> { };
            list.Add(new Peliculas { Code=false, Genero= "Genero1", Titulo= "Titulo1" });
            list.Add(new Peliculas { Code = false, Genero = "Genero2", Titulo = "Titulo2" });
            list.Add(new Peliculas { Code = false, Genero = "Genero3", Titulo = "Titulo3" });
            list.Add(new Peliculas { Code = false, Genero = "Genero4", Titulo = "Titulo4" });
            return View(list);
        }
    [HttpPost]
        public ActionResult Edit(List<Peliculas> c)
        {
            return View(c);
        }
     <tr>
                        <td>
                             @Html.CheckBoxFor(m=>Model[i].Code)                      
                        </td>
                        <td>
                            @Html.TextBoxFor(m => Model[i].Titulo)
                                                                                 
                        </td>
                        <td>
                            @Html.TextBoxFor(m => Model[i].Genero)
                                                       
                        </td>
                    </tr>

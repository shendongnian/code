    [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Login(UsuarioModel usuariomodel)
            {
                if (ModelState.IsValid) //checa se é valido
                {
                    if (usuariomodel.Usuario != "" && usuariomodel.Senha != "") //se não estiver vazio
                    {
                        UsuarioBLL usuBll = new UsuarioBLL();
                        var result = usuBll.VerificarUsuario(usuariomodel);
    
                        if (result)
                        {
                            Session["UsuarioID"] = usuariomodel.IdUser.ToString();
                            Session["NomeUsuario"] = usuariomodel.Usuario.ToString();
    
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
    
                ModelState.AddModelError("", "Usuário ou senha incorretos.");
    
                return View();
            }

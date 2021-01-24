    public ActionResult AgregarComentario(NotasAdjuntas nota)
        {
            try
            {
                var localId = int.Parse(Request["LocalID"]);
                nota.username = Session["Username"].ToString();
                using (var db = new AutoContex())
                {
                    nota.local = db.Locales.Find(localId);
                    db.Entry(nota.local).Reference(p => p.Proveedor).Load();
                    db.Notas.Add(nota);
                    db.SaveChanges();
                    if (nota.Asunto.Contains("capa"))
                    {
                        NewCommentEmail.GmailUsername = "youremail@gmail.com";
                        NewCommentEmail.GmailPassword = "yourpassword";
                        NewCommentEmail mailer = new NewCommentEmail();
                        mailer.ToEmail = "Emailto@gmail.com";
                        mailer.Subject = nota.Asunto;
                        mailer.Body = nota.local.NuevoId + " --  --" + nota.local.NombreComercio + "<br />" + nota.Detalle + "<br /> Hora:" + nota.Hora;
                        mailer.IsHtml = true;
                        mailer.Send();
                    }
                }
                return RedirectToAction("Details", new { @id = localId });
            }
            catch
            {
                return View();
            }
        }

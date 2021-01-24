    public ActionResult ExportPDF()
            {
                return new ActionAsPdf("Index")
                {
                    FileName = Server.MapPath("~/Content/Relato.pdf"),
                    PageOrientation = Rotativa.Options.Orientation.Landscape,
                    PageSize = Rotativa.Options.Size.A4
                };
            }

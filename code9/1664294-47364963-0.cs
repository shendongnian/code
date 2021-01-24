                 string fn = Guid.NewGuid() + Path.GetExtension(file.FileName);
                 file.SaveAs(Path.Combine(Server.MapPath("~/assets/image/"),fn));
            }
            if (ext.ToLower() == ".pdf")
            {
                string fn = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/assets/pdf/"), fn));
            }
            if (ext.ToLower() == ".doc" || ext.ToLower() == ".docx")
            {
                string fn = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/assets/doc/"), fn));
            }
            if (ext.ToLower() == ".xls" || ext.ToLower() == ".xlsx")
            {
                string fn = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/assets/excel/"), fn));
            }

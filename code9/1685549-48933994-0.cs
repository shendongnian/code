        public void DownloadCompanyDoc(int id)
        {
            try
            {
                var getFile = rep.GetCompanyDocById(id);
                var path = Path.Combine(HostingEnvironment.MapPath("~/Documents/CompanyDocs"), getFile);
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Response.Clear();
                    Response.AppendHeader("content-disposition", "attachment; filename=" + getFile);
                    Response.AddHeader("Content-Length", file.Length.ToString());
                    Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Octet;
                    Response.WriteFile(path);
                    Response.TransmitFile(path);
                    Response.Flush();
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

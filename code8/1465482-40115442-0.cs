    public Stream Downloadfile(string filename)
            {
                WebOperationContext.Current.OutgoingResponse.Headers["Content-Disposition"] = "attachment; filename=" + filename;
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";
                return File.OpenRead(filename);
            }

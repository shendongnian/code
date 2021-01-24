    private static string GetSPFileBinary(ClientContext ctx, string fileUrlPath)
        {
            ctx.RequestTimeout = Int32.MaxValue;
            var spFile = ctx.Web.GetFileByServerRelativeUrl(fileUrlPath);
            var spFileContent = spFile.OpenBinaryStream();
            ctx.Load(spFile);
            ctx.ExecuteQuery();
            MemoryStream stream = new MemoryStream();
            if (spFileContent != null && spFileContent.Value != null)
            {
                spFileContent.Value.CopyTo(stream);
            }
             byte[] docBytes = stream.ToArray();            
             return Convert.ToBase64String(docBytes);
        }

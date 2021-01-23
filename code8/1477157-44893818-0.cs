            var stream = new MemoryStream(package.GetAsByteArray());
            Response.AppendHeader("content-disposition", "attachment; filename=MyFile.xlsx");
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(stream.ToArray());
            Response.End();

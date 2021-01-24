            byte[] fileContent = billContent.Content;
            string base64 = Convert.ToBase64String(fileContent);
            Response.Headers.Remove("Content-Disposition");
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.Headers.Add("Content-Disposition", "inline; filename=MyPdfFile.pdf");
            return File(fileContent, "applicaton/pdf"); 

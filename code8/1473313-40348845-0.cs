            Response.Clear();
            Response.AddHeader("Content-Length", binaryFile.Length.ToString(CultureInfo.InvariantCulture));
            //Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", title)); // save file as attachment
            Response.AddHeader("Content-Disposition", string.Format("inline; filename={0}", title)); // display inline in browser
            Response.AddHeader("Content-Type", "application/pdf");
            Response.BinaryWrite(binaryFile);
            Response.Flush();
            Response.End();

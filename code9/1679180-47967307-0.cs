    string date = Helper.ToPersianDate(DateTime.Now).Replace("/", "");
                date += ".csv";
                Response.Clear();
                Response.AppendHeader("content-disposition", "attachment; filename=" + date);
                Response.ContentType = "text/csv";
                Response.Charset = Encoding.Unicode.ToString();
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                /*
                 save utf-8 with BOM
                 GetPreamble
                 */                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    Response.Write(r[0]);
                    Response.Write("\r\n");
                }
                Response.End();      

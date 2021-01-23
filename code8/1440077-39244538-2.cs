exportToExcel("SELECT * FROM yourTable", "myFileName");
        using OfficeOpenXml;
        using OfficeOpenXml.Style;
        using System;
        using System.Configuration;
        using System.Data;
        using System.Data.SqlClient;
        using System.Drawing;
        using System.Globalization;
        using System.Web;
        //=== create an excel document =========================================
        public static void exportToExcel(string sqlQuery, string fileName)
        {
            HttpResponse Response = HttpContext.Current.Response;
            DataTable dt = loadExternalDataTable(sqlQuery);
            using (ExcelPackage p = new ExcelPackage())
            {
                //create a new workbook
                p.Workbook.Properties.Author = "VDWWD";
                p.Workbook.Properties.Title = fileName;
                p.Workbook.Properties.Created = DateTime.Now;
                //create a new worksheet
                p.Workbook.Worksheets.Add(fileName);
                ExcelWorksheet ws = p.Workbook.Worksheets[1];
                ws.Name = fileName;
                ws.Cells.Style.Font.Size = 11;
                ws.Cells.Style.Font.Name = "Calibri";
                createExcelHeader(ws, dt);
                createExcelData(ws, dt);
                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                //make all columms just a bit wider, they would sometimes not fit
                for (int col = 1; col <= ws.Dimension.End.Column; col++)
                {
                    ws.Column(col).Width = ws.Column(col).Width + 1;
                }
                //send the file to the browser
                byte[] bin = p.GetAsByteArray();
                Response.ClearHeaders();
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-length", bin.Length.ToString());
                Response.AddHeader("content-disposition", "attachment; filename=\"" + fileName + ".xlsx\"");
                Response.OutputStream.Write(bin, 0, bin.Length);
                Response.Flush();
                Response.Close();
                Response.End();
            }
        }
        //=== create the excel sheet header row =========================================
        private static void createExcelHeader(ExcelWorksheet ws, DataTable dt)
        {
            int colindex = 1;
            //loop all the columns
            foreach (DataColumn dc in dt.Columns)
            {
                var cell = ws.Cells[1, colindex];
                //make the text bold
                cell.Style.Font.Bold = true;
                //make the background of the cell gray
                var fill = cell.Style.Fill;
                fill.PatternType = ExcelFillStyle.Solid;
                fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#BFBFBF"));
                //fill the cell with the text
                cell.Value = dc.ColumnName.ToUpper();
                colindex++;
            }
        }
        //=== create the excel sheet data =========================================
        private static void createExcelData(ExcelWorksheet ws, DataTable dt)
        {
            int colindex = 0;
            int rowindex = 1;
            //loop all the rows
            foreach (DataRow dr in dt.Rows)
            {
                colindex = 1;
                rowindex++;
                //loop all the columns
                foreach (DataColumn dc in dt.Columns)
                {
                    var cell = ws.Cells[rowindex, colindex];
                    string datatype = dc.DataType.ToString();
                    //fill the cell with the data in the correct format, needs to be done here because the headder row makes every column a string otherwise
                    if (datatype == "System.Decimal" || datatype == "System.Double" || datatype == "System.Float")
                    {
                        if (!string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            cell.Value = Convert.ToDecimal(dr[dc.ColumnName]);
                        cell.Style.Numberformat.Format = "0.00";
                    }
                    else if (datatype == "System.Int16" || datatype == "System.Int32" || datatype == "System.Int64" || datatype == "System.Long")
                    {
                        if (!string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            cell.Value = Convert.ToInt64(dr[dc.ColumnName]);
                    }
                    else if (datatype == "System.Bool" || datatype == "System.Boolean")
                    {
                        if (!string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            cell.Value = Convert.ToBoolean(dr[dc.ColumnName]); ;
                    }
                    else if (datatype == "System.DateTime")
                    {
                        if (!string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            cell.Value = Convert.ToDateTime(dr[dc.ColumnName]);
                        cell.Style.Numberformat.Format = DateTimeFormatInfo.CurrentInfo.ShortDatePattern;
                    }
                    else
                    {
                        cell.Value = dr[dc.ColumnName];
                    }
                    colindex++;
                }
            }
        }
        //=== create a datatable from a query  =========================================
        public static DataTable loadExternalDataTable(string sqlQuery)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString()))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, connection))
            {
                try
                {
                    adapter.Fill(dt);
                }
                catch
                {
                }
            }
            return dt;
        }

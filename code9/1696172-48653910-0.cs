     public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyGridView.DataSource = LoadData();
            MyGridView.DataBind();
        }
        private DataTable LoadData()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("COLLEGE", typeof(string)),
                            new DataColumn("COLLEGE DESC", typeof(string)),
                            new DataColumn("UNDERGRADUATE",typeof(double)),
                            new DataColumn("GRADUATE",typeof(double)),
                            new DataColumn("LAW",typeof(double)),
                            new DataColumn("TOTAL",typeof(double)),
            });
            dt.Rows.Add("AG", "College of Ag Sci and", 1902, 401, 0, 2303);
            dt.Rows.Add("AR", "College of Architecture", 510, 89, 0, 599);
            dt.Rows.Add("AS", "Coll of Arts and Science", 9558, 1281, 0, 10839);
            dt.Rows.Add("BA", "Rawls Coll of Business", 4042, 574, 0, 4616);
            dt.Rows.Add("ED", "College of Education", 823, 1373, 0, 2196);
            dt.Rows.Add("EN", "College of Engineering", 4912, 826, 0, 5738);
            dt.Rows.Add("GR", "Graduate School", 0, 254, 0, 254);
            dt.Rows.Add("HR", "Honors College", 22, 0, 0, 22);
            dt.Rows.Add("HS", "College of Human ...", 2813, 464, 0, 3277);
            dt.Rows.Add("LW", "School of Law", 0, 0, 445, 445);
            dt.Rows.Add("MC", "Coll of Media and ...", 1855, 232, 0, 2087);
            dt.Rows.Add("UN", "Texas Tech University", 3497, 4, 0, 3501);
            dt.Rows.Add("VP", "Coll of Visual and", 803, 316, 0, 1119);
            
            return dt;
        }
        protected void Export_Click(object sender, EventArgs e)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells["J1"].Value = "TEXAS TECH UNIVERSITY";
                workSheet.Cells["J1"].Style.Font.Size = 24;
                workSheet.Cells["J1"].Style.Font.Bold = true;
                workSheet.Cells["I2"].Value = "DEPARTMENT OF INSTITUTIONAL RESEARCH";
                workSheet.Cells["I2"].Style.Font.Size = 20;
                workSheet.Cells["I2"].Style.Font.Bold = true;
                workSheet.Cells["J3"].Value = "test".ToUpper();
                workSheet.Cells["J3"].Style.Font.Bold = true;
                workSheet.Cells["L4"].Value = "(UnCertified Data)";
                workSheet.Cells["A7:F7"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A7:F7"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                workSheet.Cells["A7:F7"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                workSheet.Cells["A21:F21"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                workSheet.Cells["A21:F21"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                workSheet.Cells["A21:F21"].Style.Font.Color.SetColor(System.Drawing.Color.White);
                var dt = MyGridView.DataSource as DataTable;
                // add total row to datatable for excel export because rowdatabound event which already calculates total doesn't make total as a part of the datatable at this time
                double totalUnderG = 0;
                double totalGrad = 0;
                double totalLaw = 0;
                double total = 0;
                foreach (var r in dt.Rows.Cast<DataRow>())
                {
                    totalUnderG += double.Parse(r[2].ToString());
                    totalGrad += double.Parse(r[3].ToString());
                    totalLaw += double.Parse(r[4].ToString());
                    total += double.Parse(r[5].ToString());
                }
                dt.Rows.Add("TTU TOTAL", "", totalUnderG, totalGrad, totalLaw, total);
                workSheet.Cells[7, 1].LoadFromDataTable(dt, true);
                workSheet.Cells["A7:F7"].AutoFitColumns();
                using (var memoryStream = new MemoryStream())
                {
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;  filename=Enrollment_Major_Classification.xlsx");
                    excel.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                    Response.Flush();
                    Response.End();
                }
            }
        }
        // Declare variable used to store value of Total
        double totalUnderG = 0;
        double totalGrad = 0;
        double totalLaw = 0;
        double total = 0;
        /// <summary>
        /// calculates total when displaying gridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // check row type
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                totalUnderG += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "UNDERGRADUATE"));
                totalGrad += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "GRADUATE"));
                totalLaw += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "LAW"));
                total += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TOTAL"));
            }
            else if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells[2].Text = String.Format("{0:N}", totalUnderG);
                e.Row.Cells[3].Text = String.Format("{0:N}", totalGrad);
                e.Row.Cells[4].Text = String.Format("{0:N}", totalLaw);
                e.Row.Cells[5].Text = String.Format("{0:N}", total);
            }
        }
    }

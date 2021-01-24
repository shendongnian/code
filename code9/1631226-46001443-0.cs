    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.IO;
    using System.Collections.ObjectModel;
    
    
    namespace AddTextToDataGridExportExcel_46000670
    {
        public partial class Default : System.Web.UI.Page
        {
            static ObservableCollection<gridEntry> gridDataSource = new ObservableCollection<gridEntry>();
            protected void Page_Load(object sender, EventArgs e)
            {
                fillDataSource();
                initializeGridView();
            }
    
            private void fillDataSource()
            {
                gridDataSource.Add(new gridEntry(1));
                gridDataSource.Add(new gridEntry(2));
                gridDataSource.Add(new gridEntry(3));
                gridDataSource.Add(new gridEntry(4));
                gridDataSource.Add(new gridEntry(5));
            }
            private void initializeGridView()
            {
                GridView1.DataSource = gridDataSource;
                GridView1.DataBind();
            }
    
    
            protected void ExportToExcel(object sender, EventArgs e)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                using (StringWriter sw = new StringWriter())
                {
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                    //To Export all pages
                    GridView1.AllowPaging = false;
                    addRowToGrid();//add text within the grid
                    initializeGridView();
    
                    GridView1.HeaderRow.BackColor = Color.White;
                    foreach (TableCell cell in GridView1.HeaderRow.Cells)
                    {
                        cell.BackColor = GridView1.HeaderStyle.BackColor;
                    }
                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        row.BackColor = Color.White;
                        foreach (TableCell cell in row.Cells)
                        {
                            if (row.RowIndex % 2 == 0)
                            {
                                cell.BackColor = GridView1.AlternatingRowStyle.BackColor;
                            }
                            else
                            {
                                cell.BackColor = GridView1.RowStyle.BackColor;
                            }
                            cell.CssClass = "textmode";
                        }
                    }
    
                    GridView1.RenderControl(hw);
    
                    //style to format numbers to string
                    string style = @"<style> .textmode { } </style>";
                    Response.Write(style);
                    Response.Write("blah blah blah");//add text before the grid
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();
                }
            }
    
            public override void VerifyRenderingInServerForm(Control control)
            {
                /* Verifies that the control is rendered */
            }
    
    
            private void addRowToGrid()
            {
                gridDataSource.Insert(0, new gridEntry { col1 = "this is my added text" });
            }
    
            private GridView addRowToGridAgain(GridView gv)
            {
                return gv;
            }
    
            protected void btn_ClickMe_Click(object sender, EventArgs e)
            {
                ExportToExcel(null, null);
            }
        }
    
        public class gridEntry
        {
            public string col1 { get; set; }
            public string col2 { get; set; }
            public string col3 { get; set; }
            public string col4 { get; set; }
            public string col5 { get; set; }
            public string col6 { get; set; }
            public string col7 { get; set; }
            public string col8 { get; set; }
    
            public gridEntry()
            {
                col1 = string.Empty;
                col2 = string.Empty;
                col3 = string.Empty;
                col4 = string.Empty;
                col5 = string.Empty;
                col6 = string.Empty;
                col7 = string.Empty;
                col8 = string.Empty;
            }
    
            public gridEntry(int index)
            {
                col1 = "col1 " + index.ToString();
                col2 = "col2 " + index.ToString();
                col3 = "col3 " + index.ToString();
                col4 = "col4 " + index.ToString();
                col5 = "col5 " + index.ToString();
                col6 = "col6 " + index.ToString();
                col7 = "col7 " + index.ToString();
                col8 = "col8 " + index.ToString();
            }
        }
    
    }

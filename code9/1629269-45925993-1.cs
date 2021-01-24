    using System;
    using System.Web.UI.WebControls;
    using System.Collections.ObjectModel;
    
    namespace UpdateGridViewOnPostBack_45921943
    {
        public partial class Default : System.Web.UI.Page
        {
            static ObservableCollection<dgvEntry> dgv1Source;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    //Not a postback
                    dgv1Source = new ObservableCollection<dgvEntry>();
                    dgv1Source.Add(new dgvEntry { field1 = "the field coming from the data source" });
                    initializeDGV(IsPostBack);
                }
                else
                {
                    //is a postback
                    if (dgv1Source == null)
                    {
                        dgv1Source = new ObservableCollection<dgvEntry>();
                    }
                    initializeDGV(IsPostBack);
                }
            }
    
            private void initializeDGV(bool isPostback)
            {
                dgv1.DataSource = dgv1Source;
                dgv1.AutoGenerateColumns = false;
                if (!isPostback)
                {
                    dgv1.DataBind();
                }
            }
    
            protected void dgv1_RowEditing(object sender, GridViewEditEventArgs e)
            {
                dgv1.EditIndex = e.NewEditIndex;
                dgv1.DataBind();
            }
    
            protected void dgv1_RowUpdating(object sender, GridViewUpdateEventArgs e)
            {
                
                GridViewRow row = dgv1.Rows[e.RowIndex];
                dgv1Source[e.RowIndex].field1 = ((TextBox)row.Cells[1].Controls[1]).Text;
                dgv1.EditIndex = -1;
                dgv1.DataBind();
            }
        }
    
        public class dgvEntry
        {
            public string field1 { get; set; }
            //public string field2 { get; set; }
            //public string field3 { get; set; }
        }
    }

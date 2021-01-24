    // ...
    using System.Windows.Forms;
    using GemBox.Spreadsheet;
    using GemBoxDataGridViewConverter = GemBox.Spreadsheet.WinFormsUtilities.DataGridViewConverter;
    namespace Excel
    {
        public partial class UserControl1 : UserControl
        {
            private void bunifuFlatButton2_Click(object sender, EventArgs e)
            {
                GemBoxDataGridViewConverter.ExportToDataGridView(...);
            }
        }
    }

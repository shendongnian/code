    using System.ComponentModel;
    using System.Windows.Forms;
    public partial class MyFolderBrowser : Component
    {
        public string Text { get; set; }
        public string SelectcedFolder {get;set;}
        public DialogResult ShowDialog()
        {
            using (var f = new Form1() { Text = this.Text })
            {
                var result = f.ShowDialog();
                //if (result == DialogResult.OK)
                //    SelectcedFolder = f.SelectedFolder;
                return result;
            }
        }
    }

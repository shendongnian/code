    public class Form1 : Form
    {
        FilesDataClass m_ListWorker = null;
        public Form1(FilesDataClass f)
        {
            this.m_ListWorker = f;
        }
    }
    var newForm = new Form1(m_ListWorker);

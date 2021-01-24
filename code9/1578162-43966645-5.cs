    public partial class FormModel : Form
    {
        MyDBEntities db2;
        public FormModel(Model obj)
        {
            db2 = new MyDBEntities();
            // code...
            db2.Models.Attach(modelBindingSource.Current as Model);
        }
    
        // code...
    }

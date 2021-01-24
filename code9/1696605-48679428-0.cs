    // CollectionEditor needs a reference to System.Design.dll
    public class MyCollectionEditor : CollectionEditor
    {
        public MyCollectionEditor(Type type)
            : base(type)
        {
        }
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm form = base.CreateCollectionForm();
            var addButton = (ButtonBase)form.Controls.Find("addButton", true).First();
            addButton.Click += (sender, e) =>
                {
                    MessageBox.Show("hello world");
                };
            return form;
        }
    }

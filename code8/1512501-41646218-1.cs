    namespace ClassLibraryManaged
    {
        public class Class1
        {
            public Class1() { }
            public int OpenForm(int a)
            {
                TestForm form = new TestForm();
                form.ShowDialog();
                return a * a;
            }
        }
    }

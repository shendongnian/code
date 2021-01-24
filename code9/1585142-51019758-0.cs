    // using statements
    // ...
    namespace SomeProgram
    {
        public class BoundClass
        {
            // Pass in a reference of the browser's form
            Form form;
            public BoundClass(Form formRef)
            {
                form = formRef;
            }
            // Open Form3 here
            public void OpenForm()
            {
                form.Invoke((MethodInvoker)delegate
                {
                    Form3 theForm = new Form3();
                    theForm.Show();
                });
            }
        }
    }

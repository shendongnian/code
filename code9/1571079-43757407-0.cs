    public partial class Form1 : Form
    {
        private Browser browser;
        public Form1()
        {
            InitializeComponent();
            browser = BrowserFactory.Create();
            browser.FinishLoadingFrameEvent += delegate (object sender, FinishLoadingEventArgs e)
            {
                if (e.IsMainFrame)
                {
                    JSValue value = browser.ExecuteJavaScriptAndReturnValue("window");
                    value.AsObject().SetProperty("Account", new Account(this));
                }
            };
            browser.LoadHTML(@"<!DOCTYPE html>
                                <html>
                                <head>
                                    <script type='text/javascript'>
                                            function sendFormData() {
                                            var firstNameValue = myForm.elements['firstName'].value;
                                            var lastNameValue = myForm.elements['lastName'].value;
                                            // Invoke the 'save' method of the 'Account' Java object.
                                            Account.Save(firstNameValue, lastNameValue);
                                            }
                                        </script>
                                </head>
                                <body>
                                <form name='myForm'>
                                    First name: <input type='text' name='firstName'/>
                                    <br/>
                                    Last name: <input type='text' name='lastName'/>
                                    <br/>
                                    <input type='button' value='Save' onclick='sendFormData();'/>
                                </form>
                                </body>
                                </html>");
            BrowserView browserView = new WinFormsBrowserView(browser);
            this.Controls.Add((Control)browserView.GetComponent());
        }
        public class Account
        {
            private Form Form;
            public Account(Form form)
            {
                this.Form = form;
            }
            public void Save(String firstName, String lastName)
            {
                string _firstname = firstName;
                Form.Invoke(new Action(() =>
                {
                    Form.Hide();
                }));
                SecondForm frm = new SecondForm(firstName);
                frm.ShowDialog(); 
            }
        }
    }

        public static bool ShowUserHTMLDialog(string formTitle, string formLabel, int formWidth, int formHeight, string html)
        {
            DialogResult formResult = DialogResult.Abort;
            var thread = new Thread
                (
                    () =>
                    {
                        var webBrowser = new WebBrowser();
                        var form = CreateBasicForm(formTitle, formLabel, formWidth, formHeight);
                        webBrowser.Name = "webWindow";
                        webBrowser.Size = new System.Drawing.Size(formWidth, formHeight - 70);
                        webBrowser.Location = new System.Drawing.Point(0, 35);
                        webBrowser.AllowWebBrowserDrop = false;
                        webBrowser.DocumentText = html;
                        form.Controls.Add(webBrowser);
                        formResult = form.ShowDialog();
                    }
                );
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return (formResult == DialogResult.OK);
        }

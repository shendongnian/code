    public static class myExtension
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            // See Update 2 for edits Mike de Klerk suggests to insert here.
            if (control.InvokeRequired)
            {
                control.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
    
    // ...
    
    protected WebBrowser WebBrowser1;
    public void loadBrowser()
    {
        new Thread(() =>
            {
                WebBrowser1 = new WebBrowser
                {
                    Location = new Point(15, 14),
                    MinimumSize = new Size(20, 20),
                    Name = "WebBrowser1",
                    ScriptErrorsSuppressed = true,
                    Size = new Size(250, 370),
                    TabIndex = 0,
                    Url = new Uri("", UriKind.Relative)
                };
                //((WebBrowser_V1)WebBrowser1.ActiveXInstance).NewWindow += (string u, int f, string n, ref object d, string h, ref bool p) =>
                //{
                //    p = true;
                //    WebBrowser1.Navigate(u);
                //};
                //WebBrowser1.DocumentCompleted += async (sender, args) =>
                //{
                //    // Code...
                //};
                WebBrowser1.Navigated += (sender, args) =>
                {
                    // Code...
                };
                //WebBrowser1.Navigate(Service.LinkTL.Find(_ => _.Valid)?.Use()?.Address);
                //NO Cross-Thread Exception
                this.InvokeIfRequired(() =>
                {
                    this.Controls.Add(webBrowser1);
                });
                // Cross-Thread Exception
                // base.Invoke(new MethodInvoker(() =>
                //{
                //    Controls.Add(WebBrowser1);
                //}));
                Application.Run();
            })
            { ApartmentState = ApartmentState.STA }.Start();
        }
    private void Form1_Load(object sender, EventArgs e)
    {
        loadBrowser();
    }

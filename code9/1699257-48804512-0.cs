            public Form1()
            {
                InitializeComponent();
                InitializeComponent();
                Control[] controls = Controls.Find("btnTest", true); //find control by name
                Button btn = controls[0] as Button;    //safe cast as Button     
                RemoveClickEvent(btn); 
                controls[0].Click += Form1_Click; //generate button click
            }
            private void Form1_Click(object sender, EventArgs e)
            {
                MessageBox.Show("control click"); 
            }
            private void btnTest_Click(object sender, EventArgs e)
            {
                MessageBox.Show("button click"); 
            }
    
            //remove all event hendlers for button 
            private void RemoveClickEvent(Button b)
            {
                FieldInfo f1 = typeof(Control).GetField("EventClick",
                    BindingFlags.Static | BindingFlags.NonPublic);
                object obj = f1.GetValue(b);
                PropertyInfo pi = b.GetType().GetProperty("Events",
                    BindingFlags.NonPublic | BindingFlags.Instance);
                EventHandlerList list = (EventHandlerList)pi.GetValue(b, null);
                list.RemoveHandler(obj, list[obj]);
            }

    private void tsLblCustomers_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            CustomerReport cr = new CustomerReport();
            cr.TopLevel = false;
            cr.AutoScroll = true;
            cr.BackColor = Color.White;
            pnlMain.Controls.Add(cr);
            cr.Show();
        }
        private void tsLblEmployees_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            EmployeeReport emp = new EmployeeReport();
            emp.TopLevel = false;
            emp.AutoScroll = true;
            emp.BackColor = Color.White;
            pnlMain.Controls.Add(emp);
            emp.Show();
            
        }
        private void tsLblVendors_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            VendorReport vend = new VendorReport();
            vend.TopLevel = false;
            vend.AutoScroll = true;
            vend.BackColor = Color.White;
            pnlMain.Controls.Add(vend);
            vend.Show();
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            WelcomeForm welcome = new WelcomeForm();
            welcome.TopLevel = false;
            welcome.AutoScroll = true;
            welcome.BackColor = Color.White;
            pnlMain.Controls.Add(welcome);
            welcome.Show();
        }

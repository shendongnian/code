    Customer[] mAccHolder = new Customer[10];
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e) {
      mAccHolder[0] = new Customer("Rich", "Bronze Account", 11);
      mAccHolder[1] = new Customer("Patrick", "Silver Account", 21);
      mAccHolder[2] = new Customer("Steve", "Gold Account", 12);
      mAccHolder[3] = new Customer("Kevin", "Platinum Account", 25);
      comboBox1.Items.Add(""); // <- add a blank selection so the user can select NO customer
      foreach (Customer r in mAccHolder) {
        comboBox1.Items.Add(r.GetName());
      }
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
      if (comboBox1.SelectedIndex == -1) {
        cstTxtBox.Text = string.Empty;
      } else {
        if (comboBox1.SelectedItem.ToString() != "") {
          Customer selectedCustomer = GetCustomer(comboBox1.SelectedItem.ToString());
          if (selectedCustomer != null)
            cstTxtBox.Text = selectedCustomer.ToString();
          else
            cstTxtBox.Text = "Customer not found!";
        }
        else {
          cstTxtBox.Text = "No Customer selected";
        }
      }
    }
    private Customer GetCustomer(string targetName) {
      foreach (Customer curCustomer in mAccHolder) {
        if (curCustomer.Name.Equals(targetName)) {
          return curCustomer;
        }
      }
      return null;
    }

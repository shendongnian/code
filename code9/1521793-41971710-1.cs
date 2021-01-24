    Label lbl = new Label();
    lbl.ID= "expense" + i.ToString(); // Change is here
    lbl.Text = expenseNameInput.Text;
    lbl.Location = new Point(15, 15);
    this.Controls.Add(lbl);

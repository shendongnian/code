    if (str < qty || str == 0)
            {
                MessageBox.Show("Insufficient Stock", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    //This statement is getting hit and exits the IF Statement
            }
            else
            {
                qty = Convert.ToInt32(quantity.Text);
                unitprice = Convert.ToDouble(dgvPOSproduct.CurrentRow.Cells[6].Value.ToString());
                totalprice = qty * unitprice;
                unittotal.Text = totalprice.ToString("0.00");
                addData
                    (
                    dgvPOSproduct.CurrentRow.Cells[0].Value.ToString(), //prod id
                    dgvPOSproduct.CurrentRow.Cells[1].Value.ToString(), //brand
                    dgvPOSproduct.CurrentRow.Cells[4].Value.ToString(), //dosage
                    dgvPOSproduct.CurrentRow.Cells[6].Value.ToString(), //qty
                    quantity.Text,
                    unittotal.Text,
                    dgvPOSproduct.CurrentRow.Cells[7].Value.ToString(),
                    dgvPOSproduct.CurrentRow.Cells[8].Value.ToString()
                    );
            }
    //But then carries on from here, which does the subtraction. 
    //You need to either move this code snippet into the else statement, or change the flow.
            int dgvPOSquantity = Convert.ToInt32(dgvPOSproduct.CurrentRow.Cells[5].Value.ToString());
            int dgvnewquantity;
            dgvnewquantity = dgvPOSquantity - qty;
            dgvPOSproduct.CurrentRow.Cells[5].Value = dgvnewquantity;
            discountremoveitem();
        }

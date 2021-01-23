    private void btnCalculate_Click(object sender, EventArgs e)       
    { 
    try            
    {
                string employeeType = txtEmployeeType.Text;
                decimal hours = Convert.ToDecimal(txtHoursWorked.Text);
                decimal revenue = Convert.ToDecimal(txtSalesRevenue.Text);
                decimal commission = Decimal.Parse(txtSalesCommission.Text);
                decimal totalPay = Decimal.Parse(txtTotalPay.Text);
              
                txtSalesRevenue.Text = revenue.ToString("c");
                txtSalesCommission.Text = commission.ToString("c");
                txtTotalPay.Text = totalPay.ToString("c");
                //Employee Types: S   = Salaried Employees
                //                HC  = Hourly Commission Employees
                //                HNC = Hourly Non-Commission Employees  
                if (employeeType == "S")
                {
                    totalPay = (300 + commission);
                    commission = (revenue * .02m);
                }
                else if (employeeType == "HC")
                {
                    totalPay = ((12 * hours) + commission);
                    commission = (revenue * .01m);
                }
                else if (employeeType == "HNC")
                {
                    totalPay = (16 * hours);
                    commission = (revenue * 0);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Invalid numeric format. Please check all entries.",
                    "Entry Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show(
                    "Overflow error. Please enter smaller values.",
                    "Entry Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    ex.GetType().ToString());
                txtTotalPay.Focus();
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

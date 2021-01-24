    if (cblTaskDetails.Items.Cast<ListItem>().Any(item => item.Selected))
                {
                    foreach (ListItem item in cblTaskDetails.Items)
                    {
                        if (item.Selected)
                        {
                            string selectedValue = item.Value;
                            DataTable dt = tdbll.GetPercent(selectedValue);
                            foreach (DataRow dr in dt.Rows)
                            {
                                percent = Convert.ToInt32(dr["PricePercent"].ToString());
                                value += (percent * Convert.ToDecimal(txtRate.Text)) / 100;
                            }
                        }
                    }
                    txtRate.Text = (Convert.ToDecimal(value + Convert.ToDecimal(txtRate.Text))).ToString();
                    txtAmount.Text = (Convert.ToDecimal(txtQuantity.Text) * Convert.ToDecimal(txtRate.Text)).ToString();
                }

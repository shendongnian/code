                string selectedName = cboVendors.SelectedItem.ToString();
                string phone = vendorPhones[selectedName];
                if (vendorPhones.ContainsKey(selectedName))
                {
                    vendorPhones[selectedName] = phone;
                }
                else
                {
                    vendorPhones.Add(selectedName, phone);
                }

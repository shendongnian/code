     void loadPage(object sender, RoutedEventArgs e) {
                using (var ctx = new Service()) {
                    try {
                        var query1 = from prod in ctx.products select prod.brand;
                        comboBox1.ItemsSource = query1.ToList();
                        var query4 = from hosp in ctx.hospitals select hosp.name;
                        comboBox4.ItemsSource = query4.ToList();
                        var query5 = (from cont in ctx.contactPersons select new { fName = cont.lastName + ", " + cont.firstName });
                        comboBox5.ItemsSource = query5.ToList();
                    } catch {
                        MessageBox.Show("ERROR 404: Database Not Found");
                    }
                }
            }

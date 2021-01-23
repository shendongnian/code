            using (checkinentrepriseEntities2 context = new checkinentrepriseEntities2())
            {
                clients clien = new clients();
                clien.date_arrival = DateTime.Parse(textBoxDateIN.Text);
                clien.arrival_time = textBoxTIME.Text;
                clien.Aller_A = comboboxPersonnel.SelectedItem.ToString();
                clien.Badge = int.Parse(comboBoxBadge.SelectedItem.ToString());
                int badgeTiped = int.Parse(comboBoxBadge.SelectedItem.ToString());
                context.clients.Add(clien);
                context.SaveChanges();
            }
Just add context.clients.Add(clien);

     if (String.IsNullOrWhiteSpace(textBox1.Text) || String.IsNullOrWhiteSpace(textBox2.Text))
        {
            MessageBox.Show("Proszę uzupełnić wszystkie pola, aby wprowadzić dane", "Błąd!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        bookings.Add(new Booking{ 
          Name = textBox1.Text,
          Surname = textBox2.Text,
          PESEL = textBox3.Text,
          Room = textBox4.Text
        });
        listBox.DataSource = null;
        listBox.DataSource = bookings; //use the datasource  property
        listBox.DisplayMember = "Room";
        listBox.ValueMember = "PESEL";

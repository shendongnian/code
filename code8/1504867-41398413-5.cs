            Booking booking = bookings.Find(c => c.PESEL == listBox.SelectedValue as string);
            if (booking == null) return;
            textBox1.Text = booking.Name;
            textBox2.Text = booking.Surname;
            textBox3.Text = booking.PESEL;
            textBox4.Text = booking.Room;

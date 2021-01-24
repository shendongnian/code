     int count = 0;
     int tal = 0;
     int Mtal = int.MaxValue;
     bool hit;
     int cunt = 0;
     private void button26_Click(object sender, EventArgs e)
     {
         while (count < 100)
         {
              foreach (var Listboxitem in listBox1.Items)
              {
                 hit = false;
                 if (int.Parse(Listboxitem.ToString()) < Mtal)
                 {
    
                     Mtal = int.Parse(Listboxitem.ToString());
                     hit = true;
                 }
                 count = count + 1;
                 if (hit)
                 {
                    cunt = count;
                 }
            }
        }
        this.listBox1.SelectedIndex = cunt - 1;
    
     }

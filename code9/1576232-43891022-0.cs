    decimal zTotal = 0;
    
    for (int i = 0; i < ds.Rows.Count; i++) {
      Label price = (Label) GridView1.Rows[i].FindControl("Label5");
      TextBox ttlqnt = (TextBox) GridView1.Rows[i].FindControl("TextBox1");
      decimal y = decimal.Parse(ttlqnt.Text);
      Label pricecal = (Label) GridView1.Rows[i].FindControl("Label2");
      decimal z = (y * decimal.Parse(price.Text));
      pricecal.Text = "Rs." + (z.ToString());
        
      zTotal += z;
    }
    
    Subtotal.Text = zTotal.ToString();

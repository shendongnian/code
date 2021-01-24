     // Are you sure that price is integer? What about 4.95$? 
     // More natural choice is double (decimal is the best for the currency) 
     double Cost;
     // Let's preserve double (but decimal is a better choice) 
     double total = 0;
     // string assigned to string; no Convert.ToInt32  
     // It's useless line, however, since costLabel.Text = total.ToString("c");
     // will rewrite the label
     costLabel.Text = priceLabel2.Text; 
     
     // Since cost is not an integer value
     Cost = double.Parse(priceLabel2.Text);
 
     // You don't want to parse twice
     total += Cost;
     costLabel.Text = total.ToString("c");

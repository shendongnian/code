     // Are you sure that price is integer? What about 4.95$? 
     // More natural choice is 
     // double Cost
     double Cost;
     double total = 0;
     // string assigned to string; no Convert.ToInt32  
     costLabel.Text = priceLabel2.Text; 
     
     // Since cost is not an integer value
     Cost = double.Parse(priceLabel2.Text);
 
     // You don't want to parse twice
     total += Cost;
     costLabel.Text = total.ToString("c");

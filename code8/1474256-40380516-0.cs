    private void operator_click(object sender, EventArgs e) {
      double v;
    
      if (!double.TryParse(textBox1.Text, out v)) {
        // textBox1.Text doesn't contain double, e.g. "bla-bla-bla"
    
        //TODO:put a warning/error message here
    
        return; 
      }
    
      // textBox1.Text has a double value which is v
      operationperformed = (sender as Button).Text;
      result = v;
      b = true; 
    }

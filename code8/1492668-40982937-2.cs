    private void Divide()
     {
       double val1 = 0.0;
       double val2 = 0.0;
       double reset = 0.0;
       if (!string.IsNullOrEmpty(mergeSortTime.Text) &&  !string.IsNullOrEmpty(selectionSortTime.Text))
       {
          //Assuming the value entered on the textboxes are numeric the second textbox is greater than 0.
          val1 = double.Parse(mergeSortTime.Text);
          val2 = double.Parse(selectionSortTime.Text);
          //To make sure that val2 is not equal to 0 before the calculation
          if(val2 != 0)
         {
         reset = val1/val2;
         resetTimeDisplay.Text = reset.ToString();
         }
      }
    }

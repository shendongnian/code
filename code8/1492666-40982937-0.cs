    private void Divide()
     {
       int val1 = 0;
       int val2 = 0;
       if (!string.IsNullOrEmpty(mergeSortTime.Text) &&  !string.IsNullOrEmpty(selectionSortTime.Text))
       {
          //Assuming the value entered on the textboxes are numeric the second textbox is greater than 0.
          val1 = int.Parse(mergeSortTime.Text);
          val2 = int.Parse(selectionSortTime.Text);
         resetTimeDisplay.Text = (val1 / val2).ToString();
      }
    }

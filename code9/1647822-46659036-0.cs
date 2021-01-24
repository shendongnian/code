    foreach (var box in checkboxList)
    {
        if (box.IsChecked && !myList.Contains(box.Text))
        {
            // if it's checked, add it to the list if it's not already there
            myList.Add(box.Text);
        }
        else if (!box.IsChecked)
        {
            // if it's not checked, try to remove it from the list
            myList.Remove(box.Text);
        }
    }

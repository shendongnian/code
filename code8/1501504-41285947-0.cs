    for (int i = 0; i < items.Count(); i++)
    {
        for (int j = 0; j < items.Count() - 1 - i; j++)
        {
            //lbl_i.Text = Convert.ToString(i);
            //lbl_j.Text = Convert.ToString(j);
            if (items[j] > items[j + 1])
            {
                swap(j, j + 1); //swaps the items at two given indecies
                draw(); // draws the array to the picturebox
            }
            while (sorting == false) //the sorting is paused
            {
                Application.DoEvents();
            }
        }
    }

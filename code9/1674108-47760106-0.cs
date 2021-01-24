        int smallestValue = 0;
        int largestValue = 0;
        for (int i = 0; i < lstNumberList.Items.Count; i++)
        {
            if(lstNumberList.Items[i] > largestValue)
            {
                largestValue = lstNumberList.Items[i];
                lblMaxResult.Text = largestValue.ToString();
            }
            if (lstNumberList.Items[i] < smallestValue)
            {
                smallestValue = lstNumberList.Items[i];
                lblMinResult.Text = smallestValue.ToString();
            }
        }

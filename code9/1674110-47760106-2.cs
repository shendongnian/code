        var smallestValue = int.MaxValue;
        var largestValue = int.MinValue;
        for (int i = 0; i < lstNumberList.Items.Count; i++)
        {
            var value = (int)lstNumberList.Items[i];
            if(value > largestValue)
            {
                largestValue = value;
                lblMaxResult.Text = largestValue.ToString();
            }
            if (value < smallestValue)
            {
                smallestValue = value;
                lblMinResult.Text = smallestValue.ToString();
            }
        }

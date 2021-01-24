    int acceptedNum;
    bool validNumber = int.TryParse(txtInsert.Text, out acceptedNum);
    if (!validNumber)
    {
        MessageBox.Show("Please input value between 1-100", "error", MessageBoxButtons.OK);
        return;
    }
    List<int> existingNumbers = lstIntegers.Items.Cast<Object>().Select(System.Convert.ToInt32).ToList();
    if (existingNumbers.Contains(acceptedNum))
    {
        MessageBox.Show("Number already exists in list", "error", MessageBoxButtons.OK);
        return;
    }
    existingNumbers.Add(acceptedNum);
    existingNumbers.Sort(); // Quicksort with 30 items
    int firstValue = existingNumbers.First();
    int lastValue = existingNumbers.Last();
    int middleValue = existingNumbers[existingNumbers.Count / 2];
    int count = lstIntegers.Items.Count;
    int maxNumbers = 30;
    if (count == maxNumbers)
    {
       MessageBox.Show("Maximum number of entries exceeded", "error", MessageBoxButtons.OK);
       btnInsert.Enabled = false;
    }
    
    lstIntegers.Items.Clear();
    lstIntegers.Items.AddRange(existingNumbers.Cast<object>().ToArray());

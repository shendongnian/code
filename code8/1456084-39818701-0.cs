    string[] amounts = File.ReadAllLines(ofd.FileName);
    int currentSum = 0;
    int totalSum = 0;
    ListItem[] amountItems = new ListItem[amounts.Length];
    for (int i = 0; i < amounts.Length; i++)
    {
         if (int.TryParse(amounts[i], out currentSum))
         {
             totalSum += currentSum;
         }
         amountItems[i] = amounts[i];
    }
    listBox.Items.AddRange(amountItems);
    TotalAmountlabel.Text = string.Format("{0}", totalSum);

    public double sum = 0;   /// it's important to declare the public variable outside of the click event. use the event only to change it's value.
    private void btnTest_Click(object sender, System.Windows.RoutedEventArgs e)
    {           
            foreach (var item in myGrid)
            {
                sum += Convert.ToDouble(item.TotalAmount);
            }
            TestWindow change = new TestWindow();
            change.Total = Convert.ToDecimal(sum);
            change.ShowDialog();
    }

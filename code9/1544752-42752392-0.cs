    List<Sale> sum = SaleViewModel.ChartMonthlySalePerYear();
    Jan = sum.FirstOrDefault((item) => item.Months = 1);
    Feb = sum.FirstOrDefault((item) => item.Months = 2);
    Mar = sum.FirstOrDefault((item) => item.Months = 3);
    Apr = sum.FirstOrDefault((item) => item.Months = 4);

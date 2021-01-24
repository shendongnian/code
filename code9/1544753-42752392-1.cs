    List<Sale> sum = SaleViewModel.ChartMonthlySalePerYear()
        .ForEach((item) => {
            switch(item.Month)
            {
                case 1:
                    Jan = item;
                    break;
                case 2:
                    Feb = item;
                    break;
                case 3:
                    Mar = item;
                    break;
                case 4:
                    Apr = item;
                    break;
                case 5:
                    May = item;
                    break;
                case 6:
                    Jun = item;
                    break;
                case 7:
                    Jul = item;
                    break;
                case 8:
                    Aug = item;
                    break;
                case 9:
                    Sept = item;
                    break;
                case 10:
                    Oct = item;
                    break;
                case 11:
                    Nov = item;
                    break;
                case 12:
                    Dec = item;
                    break;
                default: //do nothing
                    break;
            }
        });
 

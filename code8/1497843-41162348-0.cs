    public static void FromDriverStatistic(this DriverStatisticsVm viewModel,  DriverStatistic model)
    {
        viewModel.PropertyA = model.PropertyA;
        viewModel.PropertyB = model.PropertyB;
        //and so on...
    }

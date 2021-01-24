    try {
            if (!ViewModel.IsBusy) {
                ViewModel.IsBusy = true;
                await this.ViewModel.FindAsync(args.QueryText);
                ViewModel.IsBusy = false;
            }
        }
        catch (Exception e) {
           ViewModel.IsBusy = false;
        }

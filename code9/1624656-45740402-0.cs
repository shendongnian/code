    private void LoadVouchers(int page)
    {
        var ViewModel = new List<ListVouchersViewModel>();
        var PageSize = gvVouchers.PageSize; // Value = 10.
        var Skip = page * PageSize; // Value = 1 * 10 = 10 so skip 10 rows.
        int SupplierId = int.TryParse(hdSupplierId.Value, out SupplierId) ? SupplierId : 0;
        int totalRowCount = 0;
        using (ApplicationDbContext Context = new ApplicationDbContext())
        {
            totalRowCount = Context.Vouchers.Count();
            var Vouchers = Context.Vouchers.Where(x => x.SupplierId == SupplierId && !x.Deleted)
                                           .OrderBy(x => x.DateIssued)
                                           .Skip(Skip);
            foreach (var Voucher in Vouchers)
            {
                // Add a new ListVoucherViewModel to the list.
            }
        }
        gvVouchers.DataSource = ViewModel;
        gvVouchers.VirtualItemCount = totalRowCount;
        gvVouchers.PageIndex = page;
        gvVouchers.DataBind();
    }

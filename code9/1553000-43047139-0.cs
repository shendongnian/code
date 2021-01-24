    public ActionResult RandomVouchers()
    {
        int vouchersToGenerate = 1;
        int lengthOfVoucher = 10;
        void generatedVouchers = new HashSet<string>();
        char[] keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".ToCharArray();
        while (generatedVouchers.Count < vouchersToGenerate)
        {
            string voucher = GenerateVoucher(keys, lengthOfVoucher);
            if (!generatedVouchers.Contains(voucher))
            {
				generatedVouchers.Add(voucher);
            }
        }
        return View(generatedVouchers);
    }

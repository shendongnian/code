    dgvDealerPrices.Sort(new PriceComparer());
    
    class PriceComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var rowX = (DataGridViewRow)x;
            var rowY = (DataGridViewRow)y;
            var strX = (string)rowX.Cells[colPrice].Value;
            var strY = (string)rowY.Cells[colPrice].Value;
            return Decimal.Compare(Decimal.Parse(strX), Decimal.Parse(strY));
        }
    }

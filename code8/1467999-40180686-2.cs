            static void Main(string[] args)
            {
                List<string> order = new List<string>() { "Full", "Partial", "Mixed" };
                var pnlist = new PalletNumberRepository().GetPalletNumbers();
                var groups = pnlist.GroupBy(x => new { x.palletstatus, x.palletno }).OrderBy(x => order.IndexOf(x.Key.palletstatus)).ThenBy(x => x.Key.palletno).ToList();
                int index = pnlist.Min(x => x.palletno);
                foreach (var group in groups)
                {
                    foreach (PalletNumberRepository.PalletNumber pallet in group)
                    {
                        pallet.palletno = index;
                    }
                    index++;
                }
            }

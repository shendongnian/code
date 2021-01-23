           static void Main(string[] args)
            {
                List<string> order = new List<string>() { "Full", "Partial", "Mixed" };
                var pnlist = new PalletNumberRepository().GetPalletNumbers();
                var groups = pnlist.GroupBy(x => x.palletstatus).OrderBy(x =>  order.IndexOf(x.Key)).ToList();
                int index = pnlist.Min(x => x.palletno);
                foreach (var group in groups)
                {
                    foreach (PalletNumberRepository.PalletNumber pallet in group)
                    {
                        pallet.palletno = index++;
                    }
                }
            }

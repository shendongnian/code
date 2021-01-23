           static void Main(string[] args)
            {
                var pnlist = new PalletNumberRepository().GetPalletNumbers();
                var groups = pnlist.GroupBy(x => x.palletstatus).ToList();
                foreach (var group in groups)
                {
                    int index = group.First().palletno;
                    foreach (PalletNumberRepository.PalletNumber pallet in group)
                    {
                        pallet.palletno = index++;
                    }
                }
            }

            if (SelectedRegions.Count > 1)
            {
                RegionId = SelectedRegions.First();
                this.Title = "Summary for " + Container.Name + " (Multiple Regions)";
            }
            else if (SelectedRegions.Count > 0)
            {
                RegionId = SelectedRegions.First();
                this.Title += string.Format(" ({0})", NodeBasic.GetNodeBasic(RegionId).Name);
            }
            else
            {
                RegionId = 0;
                this.Title = "Summary for " + Container.Name;
            }

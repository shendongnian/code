     public override int SaveChanges()
     {
       List<int> orphanedScanIds = new List<int>();
       foreach (var item in this.ChangeTracker.Entries().Where(e => e.Entity is Item && e.State == EntityState.Modified))
       {
          var original = (int?)item.OriginalValues[nameof(Item.ScanId)];
          var current = (int?)item.CurrentValues[nameof(Item.ScanId)];
          if (original.HasValue && !current.HasValue)
          {
              orphanedScans.Add(original.Value);
          }
       }
       var orphanedScans = this.Scans.Where(s => orphanedScans.Contains(s.ScanId)).ToList();
       foreach (var orphanedScan in orphanedScans)
       {
          this.Scans.Remove(orphanedScan);
       }
       return base.SaveChanges();
     }

        using (dt = DataTarget.AttachToProcess(proc.Id, 100, AttachFlag.Passive))
        {
            // since 4.0 we can possibly find more than one runtime (side-by-side CLRs) in one AppDomain...
            if (dt.ClrVersions.Count > 0)
            {
                foreach (var clr in dt.ClrVersions)
                {
                    Console.WriteLine(clr.Version + " " + clr.Flavor.ToString());
                }
            }
        }

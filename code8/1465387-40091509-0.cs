    public static void RefreshKeys(string metadataLocation)
    {
        IssuingAuthority issuingAuthority = ValidatingIssuerNameRegistry.GetIssuingAuthority(metadataLocation);
        bool newKeys = false;
        foreach (string thumbprint in issuingAuthority.Thumbprints)
        {
            if (!ContainsKey(thumbprint))
            {
                newKeys = true;
                break;
            }
        }
        if (newKeys)
        {
            using (TenantDbContext context = new TenantDbContext())
            {
                context.IssuingAuthorityKeys.RemoveRange(context.IssuingAuthorityKeys);
                foreach (string thumbprint in issuingAuthority.Thumbprints)
                {
                    context.IssuingAuthorityKeys.Add(new IssuingAuthorityKey { Id = thumbprint });
                }
                // Get the Tenant IDs we have been supplied with
                IEnumerable<string> tenantIds = issuingAuthority.Issuers.Select(i => i.TrimEnd('/').Split('/').Last());
                // Exclude any that already exist in the database
                List<string> newTenantIds = tenantIds.Except(context.Tenants.Select(t => t.Id)).ToList();
                // Add only the new Tenant instances to the database
                foreach (string tenantId in newTenantIds)
                {
                    context.Tenants.Add(new Tenant { Id = tenantId });
                }
                context.SaveChanges();
            }
        }
    }

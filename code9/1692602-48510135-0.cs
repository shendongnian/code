    services.AddMvc()
        .ConfigureApplicationPartManager(m =>
        {
            var part = m.ApplicationParts.FirstOrDefault(p => p.Name == "AssemblyNameToRemove");
            if (part != null)
                m.ApplicationParts.Remove(part);
        });

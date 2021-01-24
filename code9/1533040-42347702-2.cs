    typeof(MeAssemblyType) // your type from Assembly-CSharp 
        .Assembly // Assembly-CSharp assembly
        .GetReferencedAssemblies() // get referenced assemblies
        .FirstOrDefault(m => 
            m.Assembly // from this assembly
            .GetTypes() // get all types
            .FirstOrDefault(t => 
                t.Name == scriptname // select first one that matches the name
            )
        )

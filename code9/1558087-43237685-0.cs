    // Update the publish path in the pubxml
    XmlPoke(publishProfile,
        "/ns:Project/ns:PropertyGroup/ns:publishUrl",
        buildPaths.PublishDirectory,
        new XmlPokeSettings {
            Namespaces = new Dictionary<string, string> {
                { "ns", "http://schemas.microsoft.com/developer/msbuild/2003" }
            }
        });

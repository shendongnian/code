        private static List<string> GetGroup(SearchResult result)
        {
            List<string> nombresPerfilAD = new List<string>();
            IADsPathname pathname = new PathnameClass();
            pathname.SetDisplayType(2);
            pathname.EscapedMode = 4;
            foreach (string groupDn in result.Properties["memberOf"])
            {
                pathname.Set(groupDn, 4);
                nombresPerfilAD.Add(pathname.GetElement(0).ToUpper());
            }
            return nombresPerfilAD;
        }

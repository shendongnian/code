    private List<Color> GetAllColors() {
            var list = new List<Color>();
            var colorType = typeof(Color);
            var propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (var propInfo in propInfos) {
                var color = Color.FromName(propInfo.Name);
                list.Add(color);
            }
            return list;
        }

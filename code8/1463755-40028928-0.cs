    var root = new TreeViewDto { Children = new List<TreeViewDto>() };
    foreach (var el in list) {
        var path = el.Name.Split('.');
        var parent = root;
        int last = path.Length - 1;
        for (int i = 0; i < last; i++) {
            parent = GetChildByLabel(parent, path[i]);
        }
        parent.Children.Add(new TreeViewDto {
            Label = path[last], Id = el.Id, Children = new List<TreeViewDto>()
        });
    }

    public IActionResult TreeData(string dir = "")
    {
        var browsingRoot = Path.Combine(_config.BaseDir, dir);
        var nodes = new List<TreeNode>();
        nodes.AddRange(RecurseDirectory(browsingRoot));
        return new ContentViewComponentResult(JsonConvert.SerializeObject(nodes));
    }

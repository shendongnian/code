    public class TreeNode
    {
        public Module Module { get; set; }
        public Module Parent { get; set; }
        public List<Module> Children { get; set; }
    }
    List<TreeNode> flatNodes = modules.Select(m => new TreeNode
                                {
                                    Module = m,
                                    Parent = m.ParentCode == null ? null : codeToModule[m.ParentCode],
                                    Children = modules.Where(cm => cm.ParentCode == m.ModuleCode).ToList();
                                }).ToList();

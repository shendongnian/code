    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication24
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                string[] Paths = {
                    "Home/Girls/Smoll",
                    "Home/Girls/Pige",
                    "Home/Girls/Manualy",
                    "Home/Man/Smoll",
                    "Home/Man/Pig",
                    "index/domain/index",
                    "index/ur"
                };
                List<List<string>> splitPaths = Paths.Select(x => x.Split(new char[] { '/' }).ToList()).ToList();
                TreeNode node = new TreeNode();
                RecursiveAdd(splitPaths, node);
                treeView1.Nodes.Add(node);
                treeView1.ExpandAll();
            }
            public void RecursiveAdd(List<List<string>> splitPaths, TreeNode node)
            {
                var groups = splitPaths.GroupBy(x => x[0]).ToList();
                foreach (var group in groups)
                {
                    TreeNode childNode = node.Nodes.Add(group.Key);
                    List<List<string>> children = group.Where(x => x.Count() > 1).Select(x => x.Skip(1).ToList()).ToList();
                    RecursiveAdd(children, childNode);
                }
            }
        }
     
    }

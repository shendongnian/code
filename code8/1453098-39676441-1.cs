    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    using System.Xml.Linq;
    using System.Text.RegularExpressions;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                treeView1.Nodes.AddRange( new TreeNode[] {
                    new TreeNode(
                        "id=\"43BDF924-5E\" text=\"System Management\" system=\"010\"", 
                        new TreeNode[] {
                            new TreeNode(
                               "id=\"36A21901-45\" text=\"Basic Information\"",
                               new TreeNode[] {
                                   new TreeNode(
                                       "id=\"7FA03116-0F\" text=\"Info\"",
                                       new TreeNode[] {
                                           new TreeNode(
                                               "id=\"74713E10-FF\" code=\"AGM-D-1240-01\" text=\"Persons\""
                                            ),
                                            new TreeNode(
                                                "id=\"5373F379-E8\" code=\"AGM-D-1260-01\" text=\"Stock\""
                                            )
                                       })
                               })
                        }),
                     new TreeNode(
                         "id=\"36A21901-45\" text=\"Google\"",
                         new TreeNode[] {
                             new TreeNode(
                                 "id=\"7FA03116-0F\" text=\"sites\"",
                                 new TreeNode[] {
                                     new TreeNode(
                                         "id=\"74876E10-FF\" code=\"MM-D-1240-01\" text=\"Serch\""
                                     ),
                                     new TreeNode(
                                         "id=\"0981F379-E8\" code=\"MM-D-1260-01\" text=\"Gmail\""
                                        )
                             })
                          })
                });
                treeView1.ExpandAll();
                XElement menu = new XElement("menu");
                foreach (TreeNode node in treeView1.Nodes)
                {
                    XElement newChild = new XElement("item");
                    menu.Add(newChild);
                    CreateXmlElement(newChild, node);
                }
            }
            public void CreateXmlElement(XElement parentElement, TreeNode parentNode)
            {
                string pattern = "(?'name'\\w+)=\"(?'value'[^\"]+)";
                MatchCollection matches = Regex.Matches(parentNode.Text, pattern);
                foreach (Match match in matches)
                {
                    parentElement.Add(new XAttribute(match.Groups["name"].Value, match.Groups["value"].Value));
                }
               
                foreach (TreeNode node in parentNode.Nodes)
                {
                    XElement newChild = new XElement("item");
                    parentElement.Add(newChild);
                    CreateXmlElement(newChild, node);
                }
            }
        }
    }

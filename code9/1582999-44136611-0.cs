    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace WindowsFormsApplication29
    {
        public partial class Form1 : Form
        {
            XDocument doc = null;
            public Form1()
            {
                InitializeComponent();
                
                folderBrowserDialog1.SelectedPath = @"c:\temp";
            }
            private void buttonBrowseForFolder_Click(object sender, EventArgs e)
            {
                folderBrowserDialog1.ShowDialog();
                textBoxFolderName.Text = folderBrowserDialog1.SelectedPath;
            }
            private void buttonCreateXml_Click(object sender, EventArgs e)
            {
                if(Directory.Exists(textBoxFolderName.Text))
                {
                    string header = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Directory></Directory> ";
                    doc = XDocument.Parse(header);
                    XElement root = doc.Root;
                    CreateXmlRecursive(textBoxFolderName.Text, root);
                }
            }
            private float CreateXmlRecursive(string folder, XElement folderElement)
            {
                folderElement.SetValue(folder);
                DirectoryInfo dInfo = new DirectoryInfo(folder);
                int numberOfFiles = 0;
                float size = 0.0f;
                foreach(FileInfo fInfo in dInfo.GetFiles())
                {
                    try
                    {
                        float fSize = fInfo.Length;
                        size += fSize;
                        folderElement.Add(new XElement("File", new object[] {
                            new XAttribute("size",fSize),
                            new XAttribute("creationDate", fInfo.CreationTime.ToShortDateString()),
                            new XAttribute("lastAccessDate", fInfo.LastAccessTime.ToShortDateString()),
                            new XAttribute("lastModifiedDate", fInfo.LastWriteTime.ToShortDateString()),
                            fInfo.Name
                        }));
                        numberOfFiles += 1;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Error : CAnnot Access File '{0}'", fInfo.Name);
                    }
                }
                foreach(string subFolder in Directory.GetDirectories(folder))
                {
                    XElement childDirectory = new XElement("Directory");
                    folderElement.Add(childDirectory);
                    float dSize =  CreateXmlRecursive(subFolder, childDirectory);
                    size += dSize;
                }
                folderElement.Add(new XAttribute[] {
                    new XAttribute("size", size),
                    new XAttribute("numberOfFiles", numberOfFiles)
                });
                return size;
            }
            private void buttonCreateTree_Click(object sender, EventArgs e)
            {
                if (doc != null)
                {
                    TreeNode rootNode = new TreeNode(doc.Root.FirstNode.ToString());
                    treeView1.Nodes.Add(rootNode);
                    AddNode(doc.Root, rootNode);
                }
            }
            private void AddNode(XElement xElement, TreeNode inTreeNode)
            {
                // An element.  Display element name + attribute names & values.
                foreach (var att in xElement.Attributes())
                {
                    inTreeNode.Text = inTreeNode.Text + " " + att.Name.LocalName + ": " + att.Value;
                }
                // Add children
                foreach (XElement childElement in xElement.Elements())
                {
                    TreeNode tNode = inTreeNode.Nodes[inTreeNode.Nodes.Add(new TreeNode(childElement.Value))];
                    AddNode(childElement, tNode);
                }
                treeView1.ExpandAll();
            }
        }
    }

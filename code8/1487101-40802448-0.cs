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
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Form1()
            {
                InitializeComponent();
                XElement bautyp = null;
                XElement file = null;
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> profils = doc.Descendants().Where(x => x.Name.LocalName.StartsWith("PROFIL_1009")).ToList();
                foreach (XElement profil in profils)
                {
                    TreeNode newNode =  treeView1.Nodes.Add(profil.Name.LocalName);
                    XElement sapnr = profil.Element("SAPNR");
                    if(sapnr != null)
                    {
                        newNode.Nodes.Add(string.Join(" : ",new string[] {"SAPNR", (string)sapnr.Attribute("VALUE")}));
                    }
                    XElement descr = profil.Element("DESCR");
                    if (descr != null)
                    {
                        TreeNode descrNode = newNode.Nodes.Add(string.Join(" : ", new string[] { "DESCR", (string)descr.Attribute("value") }));
                        bautyp = descr.Element("BAUTYP");
                        if (bautyp != null)
                        {
                            descrNode.Nodes.Add(string.Join(" : ", new string[] { "BAUTYP", (string)bautyp.Attribute("value") }));
                        }
                        file = descr.Element("FILE");
                        if (file != null)
                        {
                            descrNode.Nodes.Add(string.Join(" : ", new string[] { "FILE", (string)file.Attribute("value") }));
                        }
                        List<XElement> technplatz = descr.Elements().Where(x => x.Name.LocalName.StartsWith("TECHNPLATZ")).ToList();
                        foreach (XElement technplat in technplatz)
                        {
                            TreeNode tplnrNode = descrNode.Nodes.Add(technplat.Name.LocalName);
                            XElement tplnr = technplat.Element("TPLNR");
                            if (tplnr != null)
                            {
                                tplnrNode.Nodes.Add(string.Join(" : ", new string[] { "TPLNR", (string)tplnr.Attribute("value") }));
                            }
                            XElement strno = technplat.Element("STRNO");
                            if (strno != null)
                            {
                                tplnrNode.Nodes.Add(string.Join(" : ", new string[] { "STRNO", (string)strno.Attribute("value") }));
                            }
                            XElement pltxt = descr.Element("PLTXT");
                            if (pltxt != null)
                            {
                                tplnrNode.Nodes.Add(string.Join(" : ", new string[] { "PLTXT", (string)pltxt.Attribute("value") }));
                            }
                        }
                    }
                    bautyp = profil.Element("BAUTYP");
                    if (bautyp != null)
                    {
                        newNode.Nodes.Add(string.Join(" : ", new string[] { "BAUTYP", (string)bautyp.Attribute("value") }));
                    }
                    file = profil.Element("FILE");
                    if (file != null)
                    {
                        newNode.Nodes.Add(string.Join(" : ", new string[] { "FILE", (string)file.Attribute("value") }));
                    }
                }
                treeView1.ExpandAll();
            }
        }
    }

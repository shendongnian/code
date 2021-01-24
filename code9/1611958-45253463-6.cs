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
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"C:\temp\cm_exp_20170714_013357.xml";
            static DataTable dt;
            public Form1()
            {
                InitializeComponent();
                this.Load += new EventHandler(this.Form1_Load);
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    dt = new DataTable();
                    dt.Columns.Add("id", typeof(string));
                    dt.Columns.Add("vsDataType", typeof(string));
                    dt.Columns.Add("vsDataFormatVersion", typeof(string));
                    dt.Columns.Add("localCellId", typeof(int));
                    dt.Columns.Add("physicalLayerCellIdGroup", typeof(int));
                    dt.Columns.Add("physicalLayerSubCellId", typeof(int));
                    dt.Columns.Add("userLabel", typeof(int));
                    dt.Columns.Add("tac", typeof(int));
                    //dt.Columns.Add("mcc", typeof(int));
                    //dt.Columns.Add("mnc", typeof(int));
                    //dt.Columns.Add("mncLength", typeof(int));
                    //dt.Columns.Add("pciConflict", typeof(string));
                    //dt.Columns.Add("enbId", typeof(int));
                    //dt.Columns.Add("cellId", typeof(int));
                    dt.Columns.Add("pciConflictCellmcc", typeof(int));
                    //dt.Columns.Add("pciConflictCellmnc", typeof(int));
                    //dt.Columns.Add("pciConflictCellmncLength", typeof(int));
                    dt.Columns.Add("earfcndl", typeof(int));
                    dt.Columns.Add("lbEUtranCellOffloadCapacity", typeof(int));
                    XDocument doc = XDocument.Load(FILENAME);
                    XElement root = doc.Root;
                    XNamespace xnNs = root.GetNamespaceOfPrefix("xn");
                    XNamespace esNs = root.GetNamespaceOfPrefix("es");
                    DataRow newRow = null;
                    XElement attributes = null;
                    foreach (XElement cell in doc.Descendants(xnNs + "VsDataContainer"))
                    {
                        attributes = cell.Element(xnNs + "attributes");
                        XElement vsDataExternalEUtranCellFDD = attributes.Element(esNs + "vsDataExternalEUtranCellFDD");
                        if (vsDataExternalEUtranCellFDD != null)
                        {
                            List<XElement> pciConflictCells = vsDataExternalEUtranCellFDD.Elements(esNs + "pciConflictCell").ToList();
                            foreach (XElement pciConflictCell in pciConflictCells)
                            {
                                newRow = dt.Rows.Add();
                                newRow["id"] = (string)cell.Attribute("id");  
                                newRow["vsDataType"] = (string)attributes.Element(xnNs + "vsDataType");
                                newRow["vsDataFormatVersion"] = (string)attributes.Element(xnNs + "vsDataFormatVersion");
                                newRow["localCellId"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "localCellId");
                                newRow["physicalLayerCellIdGroup"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "physicalLayerCellIdGroup");
                                newRow["physicalLayerSubCellId"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "physicalLayerSubCellId");
                                newRow["tac"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "tac");
                                //XElement activePlmnList = vsDataExternalEUtranCellFDD.Element(esNs + "activePlmnList");
                                // newRow["mcc"] = (int)activePlmnList.Element(esNs + "mcc");
                                // newRow["mnc"] = (int)activePlmnList.Element(esNs + "mnc");
                                // newRow["mncLength"] = (int)activePlmnList.Element(esNs + "mncLength");
                                // if (((string)vsDataExternalEUtranCellFDD.Element(esNs + "pciConflict")).Length > 0) newRow["pciConflict"] = string.Join(",", vsDataExternalEUtranCellFDD.Elements(esNs + "pciConflict").Select(x => (string)x)); 
                                if (pciConflictCell != null)
                                {
                                    if ((pciConflictCell.Element(esNs + "mcc") != null) && ((string)pciConflictCell.Element(esNs + "mcc")).Length > 0)
                                    {
                                        newRow["pciConflictCellmcc"] = (int)pciConflictCell.Element(esNs + "mcc");
                                    }
                                }
                                newRow["earfcndl"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "earfcndl");
                                newRow["lbEUtranCellOffloadCapacity"] = (int)vsDataExternalEUtranCellFDD.Element(esNs + "lbEUtranCellOffloadCapacity");
                            }
                        }
                        else
                        {
                            newRow = dt.Rows.Add();
                            newRow["id"] = (string)cell.Attribute("id");
                            attributes = cell.Element(xnNs + "attributes");
                            newRow["vsDataType"] = (string)attributes.Element(xnNs + "vsDataType");
                            newRow["vsDataFormatVersion"] = (string)attributes.Element(xnNs + "vsDataFormatVersion");
                        }
                    }
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            }
        }
    }

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
            const string FILENAME = @"c:\temp\cm_exp_20170712_221837.xml";
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
                    dt.Columns.Add("rac", typeof(int));
                    dt.Columns.Add("lac", typeof(int));
                    dt.Columns.Add("primaryCpichPower", typeof(int));
                    dt.Columns.Add("primaryScramblingCode", typeof(int));
                    dt.Columns.Add("uarfcnDl", typeof(int));
                    dt.Columns.Add("uarfcnUl", typeof(int));
                    dt.Columns.Add("mnc", typeof(int));
                    dt.Columns.Add("mcc", typeof(int));
                    dt.Columns.Add("rncId", typeof(int));
                    dt.Columns.Add("cId", typeof(int));
                    dt.Columns.Add("userLabel", typeof(string));
                    dt.Columns.Add("vsDataType", typeof(string));
                    dt.Columns.Add("vsDataFormatVersion", typeof(string));
                    dt.Columns.Add("individualOffset", typeof(int));
                    dt.Columns.Add("maxTxPowerUl", typeof(int));
                    dt.Columns.Add("qQualMin", typeof(int));
                    dt.Columns.Add("qRxLevMin", typeof(int));
                    dt.Columns.Add("agpsEnabled", typeof(int));
                    dt.Columns.Add("hsdschSupport", typeof(int));
                    dt.Columns.Add("edchSupport", typeof(int));
                    dt.Columns.Add("edchTti2Support", typeof(int));
                    dt.Columns.Add("enhancedL2Support", typeof(int));
                    dt.Columns.Add("fdpchSupport", typeof(int));
                    dt.Columns.Add("multiCarrierSupport", typeof(int));
                    dt.Columns.Add("cpcSupport", typeof(int));
                    dt.Columns.Add("qam64MimoSupport", typeof(int));
                    dt.Columns.Add("transmissionScheme", typeof(int));
                    dt.Columns.Add("parentSystem", typeof(string));
                    dt.Columns.Add("mncLength", typeof(int));
                    dt.Columns.Add("hsAqmCongCtrlSpiSupport", typeof(string));
                    dt.Columns.Add("hsAqmCongCtrlSupport", typeof(int));
                    dt.Columns.Add("srvccCapability", typeof(int));
                    dt.Columns.Add("reportingRange1a", typeof(int));
                    dt.Columns.Add("reportingRange1b", typeof(int));
                    dt.Columns.Add("timeToTrigger1a", typeof(int));
                    dt.Columns.Add("timeToTrigger1b", typeof(int));
                    dt.Columns.Add("rimCapable", typeof(int));
                    dt.Columns.Add("lbUtranCellOffloadCapacity", typeof(int));
                    XDocument doc = XDocument.Load(FILENAME);
                    XElement root = doc.Root;
                    XNamespace unNs = root.GetNamespaceOfPrefix("un");
                    XNamespace xnNs = root.GetNamespaceOfPrefix("xn");
                    XNamespace esNs = root.GetNamespaceOfPrefix("es");
                    foreach (XElement cell in doc.Descendants(unNs + "ExternalUtranCell"))
                    {
                        DataRow newRow = dt.Rows.Add();
                        newRow["id"] = (string)cell.Attribute("id");
                        XElement attributes = cell.Element(unNs + "attributes");
                        if (((string)attributes.Element(unNs + "rac")).Length > 0) newRow["rac"] = (int)attributes.Element(unNs + "rac");
                        if (((string)attributes.Element(unNs + "lac")).Length > 0) newRow["lac"] = (int)attributes.Element(unNs + "lac");
                        newRow["primaryCpichPower"] = (int)attributes.Element(unNs + "primaryCpichPower");
                        newRow["primaryScramblingCode"] = (int)attributes.Element(unNs + "primaryScramblingCode");
                        newRow["uarfcnDl"] = (int)attributes.Element(unNs + "uarfcnDl");
                        if (((string)attributes.Element(unNs + "uarfcnUl")).Length > 0) newRow["uarfcnUl"] = (int)attributes.Element(unNs + "uarfcnUl");
                        newRow["mnc"] = (int)attributes.Element(unNs + "mnc");
                        newRow["mcc"] = (int)attributes.Element(unNs + "mcc");
                        newRow["rncId"] = (int)attributes.Element(unNs + "rncId");
                        newRow["cId"] = (int)attributes.Element(unNs + "cId");
                        newRow["userLabel"] = (string)attributes.Element(unNs + "userLabel");
                        XElement vsDataContainer = cell.Element(xnNs + "VsDataContainer");
                        XElement vsDataContainerAttributes = vsDataContainer.Element(xnNs + "attributes");
                        newRow["vsDataType"] = (string)vsDataContainerAttributes.Element(xnNs + "vsDataType");
                        newRow["vsDataFormatVersion"] = (string)vsDataContainerAttributes.Element(xnNs + "vsDataFormatVersion");
                        XElement vsDataExternalUtranCell = vsDataContainerAttributes.Element(esNs + "vsDataExternalUtranCell");
                        newRow["individualOffset"] = (int)vsDataExternalUtranCell.Element(esNs + "individualOffset");
                        newRow["maxTxPowerUl"] = (int)vsDataExternalUtranCell.Element(esNs + "maxTxPowerUl");
                        newRow["qQualMin"] = (int)vsDataExternalUtranCell.Element(esNs + "qQualMin");
                        newRow["qRxLevMin"] = (int)vsDataExternalUtranCell.Element(esNs + "qRxLevMin");
                        newRow["agpsEnabled"] = (int)vsDataExternalUtranCell.Element(esNs + "agpsEnabled");
                        XElement cellCapability = vsDataExternalUtranCell.Element(esNs + "cellCapability");
                        newRow["hsdschSupport"] = (int)cellCapability.Element(esNs + "hsdschSupport");
                        newRow["edchSupport"] = (int)cellCapability.Element(esNs + "edchSupport");
                        newRow["edchTti2Support"] = (int)cellCapability.Element(esNs + "edchTti2Support");
                        newRow["enhancedL2Support"] = (int)cellCapability.Element(esNs + "enhancedL2Support");
                        newRow["fdpchSupport"] = (int)cellCapability.Element(esNs + "fdpchSupport");
                        newRow["multiCarrierSupport"] = (int)cellCapability.Element(esNs + "multiCarrierSupport");
                        newRow["cpcSupport"] = (int)cellCapability.Element(esNs + "cpcSupport");
                        newRow["qam64MimoSupport"] = (int)cellCapability.Element(esNs + "qam64MimoSupport");
                        newRow["transmissionScheme"] = (int)vsDataExternalUtranCell.Element(esNs + "transmissionScheme");
                        newRow["parentSystem"] = (string)vsDataExternalUtranCell.Element(esNs + "parentSystem");
                        newRow["mncLength"] = (string)vsDataExternalUtranCell.Element(esNs + "mncLength");
                        newRow["hsAqmCongCtrlSpiSupport"] = string.Join(",", vsDataExternalUtranCell.Elements(esNs + "hsAqmCongCtrlSpiSupport").Select(x => (string)x));
                        newRow["hsAqmCongCtrlSupport"] = (int)vsDataExternalUtranCell.Element(esNs + "hsAqmCongCtrlSupport");
                        newRow["srvccCapability"] = (int)vsDataExternalUtranCell.Element(esNs + "srvccCapability");
                        newRow["reportingRange1a"] = (int)vsDataExternalUtranCell.Element(esNs + "reportingRange1a");
                        newRow["reportingRange1b"] = (int)vsDataExternalUtranCell.Element(esNs + "reportingRange1b");
                        newRow["timeToTrigger1a"] = (int)vsDataExternalUtranCell.Element(esNs + "timeToTrigger1a");
                        newRow["timeToTrigger1b"] = (int)vsDataExternalUtranCell.Element(esNs + "timeToTrigger1b");
                        newRow["rimCapable"] = (int)vsDataExternalUtranCell.Element(esNs + "rimCapable");
                        newRow["lbUtranCellOffloadCapacity"] = (int)vsDataExternalUtranCell.Element(esNs + "lbUtranCellOffloadCapacity");
                        newRow["agpsEnabled"] = (int)vsDataExternalUtranCell.Element(esNs + "agpsEnabled");
                    }
                    dataGridView1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }

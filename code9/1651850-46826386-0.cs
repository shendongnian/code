    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            const string FILENAME = @"c:\temp\test.xml";
            public Dictionary<string, Dictionary<string, RadioButton>> radioPanels = new Dictionary<string, Dictionary<string, RadioButton>>();
            public Form1()
            {
                InitializeComponent();
                int radioButtonCounter = 0;
                int count = 0;
                int WidthPanelsRow1 = 100;
                int heightPanelsRow1 = 50;
                Font font1 = new Font(this.Font, FontStyle.Regular);
                XmlDocument doc = new XmlDocument();
                doc.Load(FILENAME);
                XmlNodeList nodes = doc.GetElementsByTagName("Lijst");
                Dictionary<string, RadioButton> dictRadioButtons;
                foreach (XmlNode node in nodes)
                {
                    radioButtonCounter += 1;
                    count += 1;
                    if (count < 4)
                    {
                        int heightRadioButtons = 0;
                        WidthPanelsRow1 += 155;
                        Panel panel = new Panel();
                        panel.Size = new Size(140, 200);
                        panel.Location = new Point(WidthPanelsRow1, heightPanelsRow1);
                        panel.Name = "panel" + count.ToString();
                        panel.BackColor = Color.LightGray;
                        Label lbl = new Label();
                        lbl.Text = node["Titel"].InnerText;
                        lbl.Location = new Point(0, 0);
                        lbl.Font = font1;
                        panel.Controls.Add(lbl);
                        dictRadioButtons = new Dictionary<string, RadioButton>();
                        radioPanels.Add(lbl.Text, dictRadioButtons);
                        int counterLastRadioButton = 0;
                        XmlNodeList waardeNodes = node.SelectNodes("Waardes");
                        foreach (XmlNode wNode in waardeNodes)
                        {
                            counterLastRadioButton += 1;
                            heightRadioButtons += 20;
                            RadioButton rb = new RadioButton();
                            rb.Text = wNode.InnerText;
                            rb.Location = new Point(5, heightRadioButtons);
                            rb.Name = node["Titel"].InnerText;
                            if (waardeNodes.Count - 1 < counterLastRadioButton)
                            {
                                rb.Checked = true;
                            }
                            panel.Controls.Add(rb);
                            dictRadioButtons.Add(rb.Text, rb);
                        }
                        this.Controls.Add(panel);
                        int countA = 0;
                        foreach (XmlNode nodeA in nodes)
                        {
                            countA += 1;
                            if (countA < 4)
                            {
                                WidthPanelsRow1 += 155;
                                Panel panelA = new Panel();
                                panelA.Size = new Size(140, 40);
                                panelA.Location = new Point(WidthPanelsRow1, heightPanelsRow1);
                                panelA.Name = "panel" + count.ToString();
     
                                XmlNodeList titelPreset = node.SelectNodes("ButtonTitel");
                                foreach (XmlNode titelNode in titelPreset)
                                {
                                    Button btn = new Button();
                                    btn.Text = titelNode.InnerText;
                                    btn.Location = new Point(0, 0);
                                    btn.Name = nodeA["ButtonTitel"].InnerText;
                                    btn.Size = new Size(140, 40);
                                }
                                this.Controls.Add(panelA);
                            }
                        }
                    }
                }
                XmlNodeList presets = doc.GetElementsByTagName("Preset");
                XmlNodeList radioButtonValues = presets[0].SelectNodes("sets");
                foreach (XmlNode rbNode in radioButtonValues)
                {
                    Dictionary<string, RadioButton> rbPanel = radioPanels[rbNode.SelectNodes("RadioButtonTitel")[0].InnerText];
                    RadioButton rb = rbPanel[rbNode.SelectNodes("RadioButtonValue")[0].InnerText];
                    rb.Checked = true;
                }
            }
        }
    }

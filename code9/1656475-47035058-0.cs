    private void exportToXmlFile(List<Device> list)
            {
                XDocument xdoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"));
                XElement elm = new XElement("CMS");
                bool flag = false;
                XElement hostDev = new XElement("Device");
                hostDev.Add(new XAttribute("Name", list.ElementAt(0).Name)); 
                hostDev.Add(new XAttribute("Type", list.ElementAt(0).TBType1));
                elm.Add(hostDev);
                xdoc.Add(elm);
                foreach (Device device in deviceToAddList)
                {
                    if (device.Name != "CM_HOST")
                    {
                        if(device.DeviceConnectedTo=="A")
                        {
                           if (device.ConnectedBy == "Directly")
                            {
                                flag = true;
                                XElement selectedElement = xdoc.Descendants()
                                .Where(x => (string)x.Attribute("Name") == device.ParentName).FirstOrDefault();
                                XElement deviceElem = new XElement("Device");
                                XElement portAelem = new XElement("PortA");
                                portAelem.Add(new XAttribute("Connected_BY", device.ConnectedBy));
                                deviceElem.Add(new XAttribute("TB", device.TBType1));
                                deviceElem.Add(new XAttribute("ParentConnectedToPort", device.ParentConnectedTo));
                                deviceElem.Add(new XAttribute("Name", device.Name));
                                deviceElem.Add(new XAttribute("Cable", device.Cable));
                                portAelem.Add(deviceElem);
                                selectedElement.Add(portAelem);
                            }
                           if(device.ConnectedBy == "MiniBot")
                            {
                                flag = true;
                                XElement selectedElement = xdoc.Descendants()
                                .Where(x => (string)x.Attribute("Name") == device.ParentName).FirstOrDefault();
                                XElement deviceElem2 = new XElement("Device");
                                XElement portAelem2 = new XElement("PortA");
                                portAelem2.Add(new XAttribute("Connected_BY", device.ConnectedBy));
                                deviceElem2.Add(new XAttribute("TB", device.TBType1));
                                deviceElem2.Add(new XAttribute("ParentConnectedToPort", device.ParentConnectedTo));
                                deviceElem2.Add(new XAttribute("MiniBot_minus_pin", device.MinusPin1));
                                deviceElem2.Add(new XAttribute("MiniBot_pluse_pin", device.PlusPin));
                                deviceElem2.Add(new XAttribute("FTDI_Port", device.FtdiPort));
                                deviceElem2.Add(new XAttribute("Name", device.Name));
                                deviceElem2.Add(new XAttribute("Cable", device.Cable));
                                portAelem2.Add(deviceElem2);
                                selectedElement.Add(portAelem2);
                            }
                                
                        }
                        if(device.DeviceConnectedTo=="B")
                        {
                            if (device.ConnectedBy == "Directly")
                            {
                                flag = true;
                                XElement selectedElement = xdoc.Descendants()
                                .Where(x => (string)x.Attribute("Name") == device.ParentName).FirstOrDefault();
                                XElement deviceElem = new XElement("Device");
                                XElement portBelem = new XElement("PortB");
                                portBelem.Add(new XAttribute("Connected_BY", device.ConnectedBy));
                                deviceElem.Add(new XAttribute("TB", device.TBType1));
                                deviceElem.Add(new XAttribute("ParentConnectedToPort", device.ParentConnectedTo));
                                deviceElem.Add(new XAttribute("Name", device.Name));
                                deviceElem.Add(new XAttribute("Cable", device.Cable));
                                portBelem.Add(deviceElem);
                                selectedElement.Add(portBelem);
                            }
                            if (device.ConnectedBy == "MiniBot")
                            {
                                flag = true;
                                XElement selectedElement = xdoc.Descendants()
                                .Where(x => (string)x.Attribute("Name") == device.ParentName).FirstOrDefault();
                                XElement deviceElem2 = new XElement("Device");
                                XElement portBelem2 = new XElement("PortB");
                                portBelem2.Add(new XAttribute("Connected_BY", device.ConnectedBy));
                                deviceElem2.Add(new XAttribute("TB", device.TBType1));
                                deviceElem2.Add(new XAttribute("ParentConnectedToPort", device.ParentConnectedTo));
                                deviceElem2.Add(new XAttribute("MiniBot_minus_pin", device.MinusPin1));
                                deviceElem2.Add(new XAttribute("MiniBot_pluse_pin", device.PlusPin));
                                deviceElem2.Add(new XAttribute("FTDI_Port", device.FtdiPort));
                                deviceElem2.Add(new XAttribute("Name", device.Name));
                                deviceElem2.Add(new XAttribute("Cable", device.Cable));
                                portBelem2.Add(deviceElem2);
                                selectedElement.Add(portBelem2);
                            }
                        }
                    }
                }
    
                if (flag == true)
                {
                    if (cmbPowerMode.Text == "PowerSplitter" || cmbPowerMode.Text == "None")
                    {
    
                        SX sx = new SX();
                        elm.Add(new XElement("Sx", new XAttribute("FTDI_port", numircFTDIPin.Value), new XAttribute("SX_power_button_pin", numircPowerPin.Value), new XAttribute("SX_SLP_S3_pin", numircs3Pin.Value), new XAttribute("SX_SLP_S4_pin", numircs4Pin.Value), new XAttribute("SX_SLP_S5_pin", numircs5Pin.Value), new XAttribute("SX_TBT_wake_N_pin", numircWakeNpin.Value), new XAttribute("SX_PCIE_wake_pin", numircWakePin.Value), new XAttribute("G3_Power_Mode", cmbPowerMode.Text)));
                        
                    }
                    else
                    {
                        MessageBox.Show("Please select Power mode value");
                    }
                        
                    xdoc.Save(Application.StartupPath + "\\Topology.xml");
                    MessageBox.Show("XML created !!!");
                    Application.Exit();
                }
                else
                    MessageBox.Show("You did not papulate data to XML file please fill up your data");
            }

                using System;
                using System.Collections.Generic;
                using System.ComponentModel;
                using System.Data;
                using System.Drawing;
                using System.Linq;
                using System.Management;
                using System.Net.NetworkInformation;
                using System.Text;
                using System.Threading.Tasks;
                using System.Windows.Forms;
            
    private void button1_Click(object sender, EventArgs e)
            {
                listBox1.Items.Clear();
                    ManagementObjectSearcher query = new
                     ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                    ManagementObjectCollection queryCollection = query.Get();
                    foreach (ManagementObject mo in queryCollection)
                    {
                        if (!(mo["Description"].ToString().Contains("VM")))
                        {
                            if (!(mo["Description"].ToString().Contains("Virtual")))
                            {
                                if (!(mo["Description"].ToString().Contains("Hyper")))
                                {
                                    string[] addresses = (string[])mo["IPAddress"];
                                    
                                    string IPConnectionMetric = Convert.ToString(mo["IPConnectionMetric"]).Trim();
        
                                    foreach (string ipaddress in addresses)
                                    {
        
                                        listBox1.Items.Add(ipaddress + ";" + IPConnectionMetric);
                                    }
        
                                }
        
    private void button2_Click(object sender, EventArgs e)
            
    {
    
        if (listBox1.Items.Count > 1)
                    {     
                        int maximum = int.MinValue;
                        int minimum = int.MaxValue;
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        
                      {
                            int output = Convert.ToInt32(listBox1.Items[i].ToString().Split(';')[1]);
                            if ((int)output > maximum)
                                maximum = (int)output;
              
                        }
        
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            int output = Convert.ToInt32(listBox1.Items[i].ToString().Split(';')[1]);
                            if ((int)output < maximum)
                                minimum = (int)output;
        
                            if (listBox1.Items[i].ToString().Contains(minimum.ToString()))
                            {       
                                var minmetric = listBox1.Items[i].ToString();
        
                                NetworkInterface[] ifConfig = NetworkInterface.GetAllNetworkInterfaces();
                                int maxHash = int.MinValue;
                                Guid D = Guid.Empty;
                                foreach (NetworkInterface net in ifConfig)
                                {
                                    if (net.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                                    {
                                        if (maxHash < net.GetPhysicalAddress().ToString().GetHashCode())
                                        {
                                            maxHash = net.GetPhysicalAddress().ToString().GetHashCode();
        
                                            foreach (UnicastIPAddressInformation ip in net.GetIPProperties().UnicastAddresses)
                                            {
        
                                                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                                {
        
                                                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                                    {
                                                        if (ip.Address.ToString().Contains(minmetric.ToString().Split(';')[0]))
                                                        {
                                                            var ID = new Guid(String.Concat("00000000-0000-0000-0000-", net.GetPhysicalAddress().ToString()));
                                                        }
                                                    }
        else
                    {
        
                        NetworkInterface[] ifConfig = NetworkInterface.GetAllNetworkInterfaces();
                        int maxHash = int.MinValue;
                        Guid D = Guid.Empty;
        
                        foreach (NetworkInterface net in ifConfig)
                        {
                            if (net.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                            {
                                if (maxHash < net.GetPhysicalAddress().ToString().GetHashCode())
                                {
                                    maxHash = net.GetPhysicalAddress().ToString().GetHashCode();
        
                                    var ID = new Guid(String.Concat("00000000-0000-0000-0000-", net.GetPhysicalAddress().ToString()));
        
                                }
                            }
                        }

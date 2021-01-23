    using System;
    using System.Windows.Forms;
    using NAudio.Wave;
    namespace NaudioAsioTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                InitialiseAsioControls();
            }
        private void InitialiseAsioControls()
        {
            // Just fill the comboBox AsioDriver with available driver names
            var asioDriverNames = AsioOut.GetDriverNames();
            foreach (string driverName in asioDriverNames)
            {
                comboBoxAsioDriver.Items.Add(driverName);
            }
            //comboBoxAsioDriver.SelectedIndex = 0;
        }
        public string SelectedDeviceName { get { return (string)comboBoxAsioDriver.SelectedItem; } }
        private void OnButtonControlPanelClick(object sender, EventArgs args)
        {
            try
            {
                using (var asio = new AsioOut(SelectedDeviceName))
                {
                    asio.ShowControlPanel();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void comboBoxAsioDriver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var asio = new AsioOut(SelectedDeviceName))
                {
                    //asio.ShowControlPanel();
                    int nrOfChannelOUTDevices = asio.DriverOutputChannelCount;
                    int nrOfChannelINDevices = asio.DriverInputChannelCount;
                    listBoxInputs.Items.Clear();
                    listBoxOutputs.Items.Clear();
                    for (int i = 0; i < nrOfChannelOUTDevices; i++)
                    {
                        string name = asio.AsioInputChannelName(i);
                        listBoxInputs.Items.Add(name);
                    }
                    for (int i = 0; i < nrOfChannelINDevices; i++)
                    {
                        string name = asio.AsioOutputChannelName(i);
                        listBoxOutputs.Items.Add(name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
    }

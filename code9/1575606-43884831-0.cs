    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Web.UI.DataVisualization.Charting;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Data.SqlClient;
    namespace BAR_CHART
     {
     public partial class Form1 : Form
      {
        private DataTable dataTable = new DataTable();
        public SqlConnection con = 
        new SqlConnection(@"MY CONNECTION STRING");
        public SqlCommand cmd, cmd1;
        public SqlDataReader dr1, dr2;
        public Form1()
        {
            InitializeComponent();
        }
        private void chart1_Click(object sender, EventArgs e)
        {
            {
                BarExample(); 
                 
            }
        }
        public void BarExample()
        {
            this.chart1.Series.Clear();
            string SelectMeterMaster = "Select * from [DB].[dbo].[MASTER] ";
           
            cmd = new SqlCommand(SelectMeterMaster, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable ds = new DataTable();
            da.Fill(ds);
           
            con.Open();
            dr1 = cmd.ExecuteReader();
            DataRow[] rows = ds.Select();
            var rowAsString = string.Join(", ", rows.Select(c => c.ToString()).ToArray());
            
            if (dr1.Read())
            {
               
                string[] seriesArray = { rowAsString };
                int[] pointsArray = { 3 };
                // Set palette
                this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
                // Set title
                this.chart1.Titles.Add("Meter");
                // Add series.
                for (int i = 1; i < 50; i++)
                {
                    System.Windows.Forms.DataVisualization.Charting.Series series = this.chart1.Series.Add(seriesArray[i]);
                    series.Points.Add(pointsArray[i]);
                }
            }
        }
     }
    }

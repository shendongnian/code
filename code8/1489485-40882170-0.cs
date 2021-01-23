    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                dataGridView1.AllowUserToAddRows = false;
                List<Zones> zones = new List<Zones>() {
                    new Zones() { 
                        Id = "AllZone", Name = "AllZone", Childrens = new List<Zones>() {
                            new Zones() { 
                                Id = "SZ001", Name = "All Stores", Childrens = new List<Zones>() {
                                    new Zones() { Id = "1", Name = "Express", Childrens = null},
                                    new Zones() { Id = "2", Name = "National", Childrens = null},
                                    new Zones() { Id = "3", Name = "Metro", Childrens = null},
                                    new Zones() { Id = "4", Name = "Scotland National", Childrens = null},
                                    new Zones() { Id = "5", Name = "Scotland Express", Childrens = null},
                                    new Zones() { Id = "6", Name = "UK London Metro", Childrens = null}
                                }
                            }
                        }
                    }
                };
                DataTable dt = new DataTable();
                dt.Columns.Add("Enabled", typeof(Boolean));
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Parent", typeof(string));
                dt.Columns["Parent"].AllowDBNull = true;
                Zones.GetChildren(dt, zones, "NULL");
                dt = dt.AsEnumerable().OrderBy(x => x.Field<string>("ID")).CopyToDataTable();
                dataGridView1.DataSource = dt;
            }
        }
        public class Zones
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public List<Zones> Childrens { get; set; }
            public static void GetChildren(DataTable dt, List<Zones> children, string parent)
            {
                foreach (Zones child in children)
                {
                    dt.Rows.Add(new object[] { false, child.Id, child.Name, parent });
                    if (child.Childrens != null)
                    {
                        GetChildren(dt, child.Childrens, child.Id);
                    }
                }
            }
        }
    }

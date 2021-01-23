    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("CrC_Type", typeof(string));
                dt.Columns.Add("Priority", typeof(int));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("Block_Name", typeof(string));
                dt.Columns.Add("Data_Type", typeof(string));
                dt.Columns.Add("Default_Value", typeof(int));
                dt.Columns.Add("Element_Name", typeof(string));
                dt.Columns.Add("Planned_Writes", typeof(int));
                XDocument doc = XDocument.Load(FILENAME);
                foreach (XElement block in doc.Descendants("DATA_MANAGER_EEPROM_BLOCK"))
                {
                    string crcType = (string)block.Attribute("Block_Crc_Type");
                    int blockPriority = (int)block.Attribute("Block_Priority");
                    string blockType = (string)block.Attribute("Block_Type");
                    string blockName = (string)block.Attribute("Name");
                    foreach(XElement element in block.Elements("DATA_ELEMENT"))
                    {
                        string dataType = (string)element.Attribute("Data_type");
                        int defaultValue = (int)element.Attribute("Default_Value");
                        string elementName = (string)element.Attribute("Name");
                        int plannedWrites = (int)element.Attribute("Number_Of_Planned_Writes");
                        dt.Rows.Add(new object[] {
                            crcType,
                            blockPriority,
                            blockType,
                            blockName,
                            dataType,
                            defaultValue,
                            elementName,
                            plannedWrites
                        });    
                    }
                }
            }
        }
    }

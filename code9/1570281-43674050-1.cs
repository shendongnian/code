    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                UpdateDoorCommand updateDoorCommand = new UpdateDoorCommand("D1","Name1","Note1");
                updateDoorCommand.WriteXml();
            }
        }
        public class UpdateDoorCommand
        {
            // string such as D1
            public string DoorId { get; set; }
            public string Name { get; set; }
            public string Notes { get; set;  }
            public UpdateDoorCommand(string doorId, string name, string notes)
            {
                DoorId = doorId;
                Name = name;
                Notes = notes;
            }
            public UpdateDoorCommand()
            {
            }
     
            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }
            public void WriteXml()
            {
                XElement doorCommand = new XElement("Door", new object[] {
                    new XAttribute("Address", DoorId),
                    new XElement("Name", Name),
                    new XElement("Notes1", Notes)
                });
               
            }
        }
    }

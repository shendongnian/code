    using LightInject;
    using System;
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var x = new Rootobject();
                x.panels = new System.Collections.Generic.Dictionary<string, panel>();
                x.panels.Add("LBL_EDITVIEW_PANEL1", new panel()
                {
                    label_value = "",
                    rows = new row[]
                    {
                        new row
                        {
                            name = "subject",
                            label_value = "Subject",
                            label = "subject",
                            type = "String",
                            required = "true",
                            CanBeSecuredForCreate = "false",
                            CanBeSecuredForRead = "false",
                            CanBeSecuredForUpdate = "false",
                        },
                        new row
                        {
                            name = "scheduledstart",
                            label_value = "Start Time",
                            label = "scheduledstart",
                            type = "DateTime",
                            required = "true",
                            CanBeSecuredForCreate = "false",
                            CanBeSecuredForRead = "false",
                            CanBeSecuredForUpdate = "false",
                        },
                    },
                });
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(x));
                Console.ReadLine();
            }
        }
    }

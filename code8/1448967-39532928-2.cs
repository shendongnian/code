        static void Main(string[] args)
        {
            int id = System.Diagnostics.Process.GetProcessesByName("WindowsFormsApplication1")[0].Id;
            AutomationElement desktop = AutomationElement.RootElement;
            AutomationElement bw = desktop.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ProcessIdProperty, id));
            AutomationElement datagrid = bw.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "dataGridView1"));
            AutomationElementCollection headers = datagrid.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Header));
            var headerCol1 = headers[1].Current.Name; ;
            var headerCol2 = headers[2].Current.Name;
            Console.WriteLine(headerCol1 + " " + headerCol2);
        }

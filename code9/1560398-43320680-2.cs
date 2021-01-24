    XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            string str = null;
            string result = string.Empty;
            List<int> Value1 = new List<int>();
            List<int> Value2 = new List<int>();
            List<string> Operator = new List<string>();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                
                xmldoc.Load(openFileDialog.FileName);
                xmlnode = xmldoc.GetElementsByTagName("Som");
                for (i = 0; i <= xmlnode.Count - 1; i++)
                {
                    xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                    str = str + xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + "  " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim() + System.Environment.NewLine;
                    Value1.Add(int.Parse(xmlnode[i].ChildNodes.Item(0).InnerText.Trim()));
                    Value2.Add(int.Parse(xmlnode[i].ChildNodes.Item(2).InnerText.Trim()));
                    Operator.Add(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                }
                tbBerekeningen.Text = str;
            }
            for (int j = 0; j < Value1.Count; j++)
            {
                if (Operator[j] == "+")
                {
                    result = result + Value1[j] + Value2[j] + System.Environment.NewLine;
                }
                //add if else block or switch cases for all the operators.
                //e.g if (Operator[j] == "-")
                
            }
            tbBerekeningen.Text = result; 

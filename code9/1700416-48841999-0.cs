        private void button1_Click(object sender, EventArgs e)
        {
           MessageBox.Show(NodeReplace(xml, "type",value));
        }
        public string NodeReplace(string xml, string nodeToFind, string newValue)
        {
            int start = xml.IndexOf("<" + nodeToFind);
            int end = xml.IndexOf("</" + nodeToFind + ">");
            string toreplace = xml.Substring(start, end + 3 + (nodeToFind.Length) - start);
            xml = xml.Replace(toreplace, newValue);
            return xml;
        }

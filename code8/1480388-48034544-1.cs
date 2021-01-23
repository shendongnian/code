    /// <summary>
        /// Read the old rdlc file and write the new one to be used for ReportViewer
        /// </summary>
        /// <param name="datos">DataTable complete from Select statement</param>
        /// <param name="rutaActualRDLC">C\Reports\Template.rdlc</param>
        /// <param name="rutaNuevaRDLC">C\Reports\NewFile.rdlc</param>
        private void LecturaRDLCXML(DataTable datos, string rutaActualRDLC, string rutaNuevaRDLC)
        {
            //Read the report file into a XMLDocument
            XmlDocument documento = new XmlDocument();
            documento.Load(rutaActualRDLC);
            //Select the node 'ReportItems' that apear when you add a Tablix element empty
            XmlNode aNode = documento.DocumentElement.FirstChild.FirstChild;
            //Override that node with your DataTable, the same DataTable you passed to a DataGridView
            aNode.InnerXml = CrearTablaDeReporteXML(datos);
            //Save the new file written
            documento.Save(rutaNuevaRDLC);
        }

        public void NewAppointment(Office.IRibbonControl control)
        {
            try
            {
                Microsoft.Office.Interop.Outlook.Application app = Globals.ThisAddIn.Application;
                Microsoft.Office.Interop.Outlook.AppointmentItem currentAppointment = (Microsoft.Office.Interop.Outlook.AppointmentItem)
                app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olAppointmentItem);
                currentAppointment.Start = DateTime.Now.AddHours(2);
                currentAppointment.End = DateTime.Now.AddHours(3);
                currentAppointment.Location = "ConferenceRoom #1";
                currentAppointment.Body = "Body of event...";
                Microsoft.Office.Interop.Word.Document docx = currentAppointment.GetInspector.WordEditor as Microsoft.Office.Interop.Word.Document;
                if (docx != null)
                {
                    Microsoft.Office.Interop.Word.Selection selected = docx.Windows[1].Selection;
                    docx.InlineShapes.AddPicture(@"c:\temp\test.jpg");
                }
                currentAppointment.AllDayEvent = false;
                currentAppointment.Subject = "Group Project";
                currentAppointment.Save();
                currentAppointment.Display(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The following error occurred: " + ex.Message);
            }
        }

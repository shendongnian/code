        private void btnSend_Click(object sender, EventArgs e)
        {
            string mailBody = "<HTML><Head><Body><table width='100%' style='border:Solid 1px Black;'>";
            foreach (DataGridViewColumn Column in dataGridView3.Columns)
            {
                mailBody += "<td style=font -size:100%'><b>" + Column.HeaderText + "</b></td>";
            }
                foreach (DataGridViewRow row in dataGridView3.Rows)
                {
                    mailBody += "<tr style=font - size:150 % '>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        mailBody += "<td style='color:black;'>" + cell.Value + "</td>";
                    }
                    mailBody += "</tr>";
                }
            mailBody += "</Head></table></Body></HTML>";
            Outlook._Application _app = new Outlook.Application();
            Outlook.MailItem mail = (Outlook.MailItem)_app.CreateItem(Outlook.OlItemType.olMailItem);
            try
            {
                mail.To = txtTo.Text;
                mail.Subject = txtSubject.Text;
                mail.HTMLBody=mailBody;
                mail.Importance = Outlook.OlImportance.olImportanceNormal;
                ((Outlook._MailItem)mail).Send();
                MessageBox.Show("Your Message has been successfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTo.Clear();
                txtSubject.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

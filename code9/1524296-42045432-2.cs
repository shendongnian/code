    private void btnSave_Click(object sender, EventArgs e)
        {
            XElement QuestsSorted = xDoc.Element("QuestsSorted");
            for (int i = 0; i < lstQuestsSorted.Items.Count; i++)
            {
                XElement qt = QuestsSorted.Elements().Skip(i).Take(1).FirstOrDefault();
                qt.Attribute("Action").Value = lstQuestsSorted.Items[i].ToString().Split(':')[0];
                qt.Attribute("NameClass").Value = lstQuestsSorted.Items[i].ToString().Split(':')[1];
            }
            xDoc.Save(path);
        }

     private void reOrderLayers(object sender, EventArgs e)
        {
            for (int i = 0; i < rootPanel.Controls.Count; i++)
            {
                rootPanel.Controls.RemoveAt(i);
                rootPanel.Refresh();
            }
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                rootPanel.Controls.Add(panelList[listBox.Items[i].ToString()]);
                rootPanel.Refresh();
            }
        }
 

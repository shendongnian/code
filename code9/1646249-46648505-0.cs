    private void radTreeView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if backspace is pressed go to previous node
            if (e.KeyChar == (char)Keys.Back)
            {
                if (m_History.Count == 0)
                    return;
                RadTreeNode nNode = m_History[m_History.Count - 1];
                //Load with the m_History[m_History.Count - 1] node from the list(m_History)
                LoadTree(nNode);
                //remove the last node
                m_History.Remove(nNode);
            }
        }

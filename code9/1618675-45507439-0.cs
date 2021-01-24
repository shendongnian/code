    if (MessageBox.Show("This will delete the file from the folder. Are you sure?", "Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                for (int i = fileDisplayListView.SelectedItems.Count - 1; i >= 0; i--)
                {
                    ListViewItem item = fileDisplayListView.SelectedItems[i];
                    string fpath = string.Empty;
                    fileDisplayListView.Items[item.Index].Remove();
                    fpath = fbd.SelectedPath.ToString() + "\\" + item.Text;
                    File.Delete(fpath);
                }

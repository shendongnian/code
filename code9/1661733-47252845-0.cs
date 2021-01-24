        private void btnSave_Click(object sender, EventArgs e)
        {
            string imageFilePath = null;
            string dataFilePath = null;
            ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
            try
            {
                // Image data
                imageFilePath = promptForFilePath("Save Chart image", "PNG Files (*.png)|*.png|JPEG Files (*.jpg,*.jpeg)|*.jpg;*.jpeg|BMP Files (*.bmp)|*.bmp|All Files (*.*)|*.*");
                if (!String.IsNullOrWhiteSpace(imageFilePath))
                {
                    switch (Path.GetExtension(imageFilePath).Replace(".", "").ToLower())
                    {
                        case "jpeg":
                        case "jpg": 
                                    format = ImageFormat.Jpeg;
                            break;
                        case "png": format = ImageFormat.Png;
                            break;
                        case "bmp": format = ImageFormat.Bmp;
                            break;
                    }
                    this.graph.SaveImage(imageFilePath, format);
                }
                // XML data
                dataFilePath = promptForFilePath("Save Chart data","XML Files (*.xml)|*.xml|All Files (*.*)|*.*");
                if (!String.IsNullOrWhiteSpace(dataFilePath)) this.graph.Serializer.Save(dataFilePath);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "btnSave_Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        string promptForFilePath(string title = "Save File", string fileFilter = "All Files (*.*)|*.*")
        {
            string result = null;
            SaveFileDialog saveFileDialog = null;
            try
            {
                saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = title;
                saveFileDialog.Filter = fileFilter;
                if(saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    result = saveFileDialog.FileName; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message, "saveChartData Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (saveFileDialog != null)
                {
                    saveFileDialog.Dispose();
                    saveFileDialog = null;
                }
            }
            return result;
        }

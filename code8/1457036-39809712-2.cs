        private void button1_Click(object sender, EventArgs e)
        {
            new AddMaterials(OnAddMaterialDelegate).Show();
        }
        private void OnAddMaterialDelegate(string material)
        {
            this.materialsList.Add(material);
        }

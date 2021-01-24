        private void PlatformasCBO_SelectedValueChanged(object sender, EventArgs e)
        {
            if (PlatformasCBO.SelectedValue != null)
            {
                SiteUrlLstBox.DataSource = this.platformasDataSet.SetupUrlConditions.Where(  p => p.platforma_id == (int)PlatformasCBO.SelectedValue).ToList();
            }
        }

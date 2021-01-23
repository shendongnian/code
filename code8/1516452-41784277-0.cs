     void kubelio_clickas (object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;
            if (clickedLabel != null) {
               clickedLabel.Visible = false;
            }
        }

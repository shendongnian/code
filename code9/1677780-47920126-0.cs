            Dictionary<string, RepositoryItemRadioGroup> repositories = new Dictionary<string, RepositoryItemRadioGroup>();
            RepositoryItemRadioGroup group1 = new RepositoryItemRadioGroup();
            group1.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Fine", "Fine"));
            group1.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Bad", "Bad"));
            repositories.Add("How are you?", group1);
            RepositoryItemRadioGroup group2 = new RepositoryItemRadioGroup();
            group2.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("Here", "Here"));
            group2.Items.Add(new DevExpress.XtraEditors.Controls.RadioGroupItem("There", "There"));
            repositories.Add("Where are you?", group2);

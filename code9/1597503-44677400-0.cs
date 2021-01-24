            `// Master 
            master.DropDownItems.
                AddRange(new System.Windows.Forms.ToolStripItem[] 
                {
                    partyMaster,
                    itemMaster,
                    taxMaster
                }
                );
            master.Name = "Master";
            master.Size = new System.Drawing.Size(125, 20);
            master.Text = "Master";
            master.Click += new System.EventHandler(master_Click);
            // Party Master
            partyMaster.Name = "PartyMaster";
            partyMaster.Size = new System.Drawing.Size(152, 22);
            partyMaster.Text = "PartyMaster";
            partyMaster.Click += new System.EventHandler(partyMaster_Click);
            // Item Master
            itemMaster.Name = "ItemMaster";
            itemMaster.Size = new System.Drawing.Size(152, 22);
            itemMaster.Text = "ItemMaster";
            // Tax Master
            taxMaster.Name = "TaxMaster";
            taxMaster.Size = new System.Drawing.Size(152, 22);
            taxMaster.Text = "TaxMaster"; //`

            CreateTable(
                "dbo.ChecklistFilleds",
                c => new
                    {
                        InternalChecklistFilledID = c.Int(nullable: false, identity: true),
                        ChecklistFilledDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InternalChecklistFilledID);
            
            CreateTable(
                "dbo.ItemsFilleds",
                c => new
                    {
                        InternalItemsFilledID = c.Int(nullable: false, identity: true),
                        DeviceCondition = c.Boolean(),
                        CheckListFilledId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InternalItemsFilledID)
                .ForeignKey("dbo.ChecklistFilleds", t => t.CheckListFilledId, cascadeDelete: true)
                .Index(t => t.CheckListFilledId);

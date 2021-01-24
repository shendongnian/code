     [Migration(201610250659)]
    public class _201610250659_AddedMinimumValue_Prices : Migration
    {
        public override void Up()
        {
            Alter.Table("Prices")
                .AddColumn("MinimunValue").AsInt32().NotNullable().WithDefaultValue(1);
        }
        public override void Down()
        {
            Delete.Column("MinimunValue")
                .FromTable("Prices");
        }
    }

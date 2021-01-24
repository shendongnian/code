    using System.Data.Entity.ModelConfiguration;
    using Nop.Plugin.Widgets.Enhancements.Domain;
    namespace Nop.Plugin.Widgets.Enhancements.Data
    {
    public class AmazonProductMap : EntityTypeConfiguration<AmazonProduct>
    {
        public AmazonProductMap()
        {
            ToTable("amazonProductInfo");
            HasKey(p => p.AmazonProductID);
            Ignore(p => p.Id); //I had to ignore this column
            //other fields omitted
        }
    }
    }

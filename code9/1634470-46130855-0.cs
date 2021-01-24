    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Data.SqlClient;
    using System.Linq;
    
    namespace ConsoleApp8
    {
    
        public class Bond : Asset
        {
            public DateTime IssueDate { get; set; }
    
            public DateTime MaturityDate { get; set; }
    
            //public BondCoupon Coupon { get; set; }
    
            //public Currency Currency { get; set; }
    
            public decimal FaceValue { get; set; }
    
            
        }
    
        public abstract class BaseAsset<T> : BaseEntity<T> where T :  new()
        {
            public string Name { get; set; }
    
            public string Isin { get; set; }
        }
    
        public class Asset : BaseAsset<Asset>
        {
        }
    
        public class BaseEntity<T> where T :  new()
        {
            public int Id { get; set; }
    
            public bool IsDeleted { get; set; }
    
    
        }
        public class BondConfiguration : EntityTypeConfiguration<Bond>
        {
            public BondConfiguration()
            {
    
                Property(b => b.FaceValue)
                    .HasColumnName("BondFaceValue")
                    .IsRequired();
            }
        }
        public  enum  AssetClass
        {
            Bond = 1
        }
        public class AssetConfiguration : EntityTypeConfiguration<Asset>
        {
            public AssetConfiguration()
            {
                Property(a => a.IsDeleted).HasColumnName("IsDeleted");
    
                HasKey(a => a.Id);
    
                ToTable("Asset");
    
                Property(a => a.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                    .HasColumnName("AssetId");
    
                Property(a => a.Name)
                    .HasColumnName("AssetName")
                    .IsRequired();
    
                Property(a => a.Isin)
                    .HasColumnName("AssetISIN");
    
                Map<Bond>(p => p.Requires("AssetClass").HasValue((int)AssetClass.Bond));
            }
        }
    
        class Db : DbContext
        {
            public DbSet<Bond> Bonds { get; set; }
            public DbSet<Asset> Assets { get; set; }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new AssetConfiguration());
                modelBuilder.Configurations.Add(new BondConfiguration());
            }
        }
    
    
    
        class Program
        {      
    
            static void Main(string[] args)
            {
    
                Database.SetInitializer(new DropCreateDatabaseAlways<Db>());
                
                using (var db = new Db())
                {
                    db.Database.Log = m => Console.WriteLine(m);
    
                    db.Database.Initialize(true);
                    
    
    
                    
                    
    
                }
    
    
                Console.WriteLine("Hit any key to exit");
                Console.ReadKey();
    
    
            }
        }
    }

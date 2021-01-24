    public class TableABCMap : EntityTypeConfiguration<TableABC>
    {
        public TableABCMap()
        {
            this.HasRequired(e => e.TableA)
                .WithMany(x => x.Relations)
                .HasForeignKey(x => x.IDTableA);
            this.HasRequired(e => e.TableB)
                .WithMany(x => x.Relations)
                .HasForeignKey(x => x.IDTableB);
            this.HasOptional(e => e.TableC)
                .WithMany(x => x.Relations)
                .HasForeignKey(x => x.IDTableC);
        }
    }

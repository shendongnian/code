            modelBuilder.Entity<Translation>(entity =>
            {
                entity.HasKey(e => e.DerivedId);
                entity.Property(e => e.DerivedId).ValueGeneratedNever();
                entity.HasOne(d => d.Word1Navigation)
                    .WithMany(p => p.TranslationWord1Navigation)
                    .HasForeignKey(d => d.Word1)
                 .HasConstraintName("FK__DerivedTa__Word1__5EBF139D");
                entity.HasOne(d => d.Word2Navigation)
                    .WithMany(p => p.TranslationWord2Navigation)
                    .HasForeignKey(d => d.Word2)
                    .HasConstraintName("FK__DerivedTa__Word2__5FB337D6");
            });
            modelBuilder.Entity<Word>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

      entity.Property(e => e.MyEnumField)
                .HasMaxLength(50)
                .HasConversion(
                    v => v.ToString(),
                    v => (MyEnum)Enum.Parse(typeof(MyEnum),v))
                    .IsUnicode(false);

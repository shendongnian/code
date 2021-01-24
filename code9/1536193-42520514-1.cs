    modelBuilder.Types().Configure(c =>
                {
                    var properties = c.ClrType.GetProperties(BindingFlags.NonPublic
                                                            | BindingFlags.Instance)
                                              .Where(p => p.Name == "IsEnabled1");
                    foreach (var p in properties)
                        c.Property(p).HasColumnName("FeatureEnable").IsRequired();
                });

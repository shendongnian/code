                    protected override void OnModelCreating(ModelBuilder modelBuilder)
                    {
                        //Optional: The version of .NET Core, used by Ef Core Migration history table
                        modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");
            
              //.. Your custom code
        
        //PersistentDbContext
    modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.DeviceFlowCodes", b =>
                        {
                            b.Property<string>("UserCode")
                                .ValueGeneratedOnAdd()
                                .HasMaxLength(200);
            
                            b.Property<string>("ClientId")
                                .IsRequired()
                                .HasMaxLength(200);
            
                            b.Property<DateTime>("CreationTime");
            
                            b.Property<string>("Data")
                                .IsRequired()
                                .HasMaxLength(50000);
            
                            b.Property<string>("DeviceCode")
                                .IsRequired()
                                .HasMaxLength(200);
            
                            b.Property<DateTime?>("Expiration")
                                .IsRequired();
            
                            b.Property<string>("SubjectId")
                                .HasMaxLength(200);
            
                            b.HasKey("UserCode");
            
                            b.HasIndex("DeviceCode")
                                .IsUnique();
            
                            b.HasIndex("UserCode")
                                .IsUnique();
            
                            b.ToTable("DeviceCodes");
                        });
            
                        modelBuilder.Entity("IdentityServer4.EntityFramework.Entities.PersistedGrant", b =>
                        {
                            b.Property<string>("Key")
                                .HasMaxLength(200);
            
                            b.Property<string>("ClientId")
                                .IsRequired()
                                .HasMaxLength(200);
            
                            b.Property<DateTime>("CreationTime");
            
                            b.Property<string>("Data")
                                .IsRequired()
                                .HasMaxLength(50000);
            
                            b.Property<DateTime?>("Expiration");
            
                            b.Property<string>("SubjectId")
                                .HasMaxLength(200);
            
                            b.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(50);
            
                            b.HasKey("Key");
            
                            b.HasIndex("SubjectId", "ClientId", "Type");
            
                            b.ToTable("PersistedGrants");
                        });
                    }

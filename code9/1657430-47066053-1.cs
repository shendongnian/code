		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
		public unsafe struct STRUCT_2
		{
			[FieldOffset(0)]
			public fixed byte Name[260];
			// Fix thanks to Ben Voigt
		}
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
		public unsafe struct STRUCT_1
		{
			void Init()
			{
				this.Count = 0;
				this.Index = 0;
			}
			[FieldOffset(0)]
			public uint Count;
			[FieldOffset(4)]    //! using 0, Count and Index is union, so got the same value. u dont want do that. right?
			public uint Index;
			[FieldOffset(8)]   //! using 100, there are some empty space, so u dont want do that. right?
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
			public STRUCT_2 Table; //! i think u want to save STRUCT_2 structure. right?
		}
		static void test3()
		{
			
			MemoryMappedFileSecurity CustomSecurity = new MemoryMappedFileSecurity();
			CustomSecurity.AddAccessRule(new System.Security.AccessControl.AccessRule<MemoryMappedFileRights>
				( "everyone"
				, MemoryMappedFileRights.FullControl
				, System.Security.AccessControl.AccessControlType.Allow));
			using (var mappedFile = MemoryMappedFile.CreateOrOpen("Local\\STRUCT_MAPPING"
														, 1024
														, MemoryMappedFileAccess.ReadWriteExecute
														, MemoryMappedFileOptions.None
														, CustomSecurity
														, System.IO.HandleInheritability.Inheritable))
			{ 
				using (var accessor = mappedFile.CreateViewAccessor())
				{
					//! writing test data.
					STRUCT_1 write_data;
					write_data.Index = 1;
					write_data.Count = 2;
					unsafe
					{
						for (int i = 0; i < 10; i++) write_data.Table.Name[i] = (byte)i;
					}
					accessor.Write<STRUCT_1>(0, ref write_data);
					//! and read test data.
					STRUCT_1 data;
					accessor.Read<STRUCT_1>(0, out data); // NO ERROR !
														  
					Console.WriteLine(data.Index);
					Console.WriteLine(data.Count);
                    //! and check data.Table.Name 
				}
			}
		}

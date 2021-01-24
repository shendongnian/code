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
					//! write data.
					STRUCT_1 write_data;
					write_data.Index = 1;
					write_data.Count = 2;
					string table_name = "TB_EDC";
					byte[] table_name_array = Encoding.UTF8.GetBytes(table_name);
					unsafe
					{
						Marshal.Copy(table_name_array, 0, (IntPtr)write_data.Table.Name, table_name_array.Length);
					}
					accessor.Write<STRUCT_1>(0, ref write_data);
					//! read data.
					STRUCT_1 data;
					accessor.Read<STRUCT_1>(0, out data); // NO ERROR !
														 
					Console.WriteLine(data.Index);
					Console.WriteLine(data.Count);
					//! check the STRUCT_2, table name.
					//! we dont know the length of name, let's find a null char for ending.
                    //! if u add a variable for name length, it will be simple.
					unsafe
					{
						int zero_index = -1;
						for (int i = 0; i < 260; i++) //! 260 is defined in STRUCT_2 for Name.
						{
							if (data.Table.Name[i] == 0)
							{
								zero_index = i;
								break;
							}
						}
						//! we find that. let's look at it.
						if (zero_index != -1)
						{
							string table_name_from_data = Encoding.UTF8.GetString(data.Table.Name, zero_index);
							Console.WriteLine(table_name_from_data);
						}
						
					}
					
				}
			}
		}

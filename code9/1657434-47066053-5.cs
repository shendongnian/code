		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct STRUCT_2
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
			public  byte[]  Name;
		}
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
		public struct STRUCT_1
		{
			void Init()
			{
				this.Count = 0;
				this.Index = 0;
			}
			public uint Count;
			public uint Index;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)] //! array size of 10.
			public STRUCT_2 [] Table;
		}
		static void test3()
		{
			
			MemoryMappedFileSecurity CustomSecurity = new MemoryMappedFileSecurity();
			CustomSecurity.AddAccessRule(new System.Security.AccessControl.AccessRule<MemoryMappedFileRights>
				( "everyone"
				, MemoryMappedFileRights.FullControl
				, System.Security.AccessControl.AccessControlType.Allow));
			using (var mappedFile = MemoryMappedFile.CreateOrOpen("Local\\STRUCT_MAPPING"
														, 10 * 1024
														, MemoryMappedFileAccess.ReadWriteExecute
														, MemoryMappedFileOptions.None
														, CustomSecurity
														, System.IO.HandleInheritability.Inheritable))
			{ 
				using (var accessor = mappedFile.CreateViewAccessor())
				{
					//! test setting.
					int table_count = 5;
					//! write data.
					STRUCT_1 write_data;
					write_data.Index = 1;
					write_data.Count = 2;
					write_data.Table = new STRUCT_2[10];
					for (int i = 0; i < 10; i++)
					{
						write_data.Table[i].Name = new byte[260];
						write_data.Table[i].Name[0] = (byte)i;
					}
					//! ----------------------------
					// Get size of struct
					int size = Marshal.SizeOf(typeof(STRUCT_1));
					byte[] data = new byte[size];
					// Initialize unmanaged memory.
					IntPtr p = Marshal.AllocHGlobal(size);
					// Copy struct to unmanaged memory.
					Marshal.StructureToPtr(write_data, p, false);
					// Copy from unmanaged memory to byte array.
					Marshal.Copy(p, data, 0, size);
					// Write to memory mapped file.
					accessor.WriteArray<byte>(0, data, 0, data.Length);
				
					// Free unmanaged memory.
					Marshal.FreeHGlobal(p);
					p = IntPtr.Zero;
					
					//! ----------------------------------------------
					STRUCT_1 read_data;
					size = Marshal.SizeOf(typeof(STRUCT_1));
					data = new byte[size];
					// Initialize unmanaged memory.
					p = Marshal.AllocHGlobal(size);
					
					// Read from memory mapped file.
					accessor.ReadArray<byte>(0, data, 0, data.Length);
					// Copy from byte array to unmanaged memory.
					Marshal.Copy(data, 0, p, size);
					// Copy unmanaged memory to struct.
					read_data = (STRUCT_1)Marshal.PtrToStructure(p, typeof(STRUCT_1));
					
					// Free unmanaged memory.
					Marshal.FreeHGlobal(p);
					p = IntPtr.Zero;
					
					Console.WriteLine(read_data.Index);
					Console.WriteLine(read_data.Count);
				}
			}
		}

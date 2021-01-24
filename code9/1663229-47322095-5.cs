		static unsafe void test3()
		{
			STRUCT_ITEM item = new STRUCT_ITEM();
			item.Effect = new STRUCT_SUB_ITEM[3];
			item.Effect[0].Type = 1;
			item.Effect[0].Values = 2;
			item.Effect[1].Type = 1;
			item.Effect[1].Values = 2;
			item.Effect[2].Type = 1;
			item.Effect[2].Values = 2;
			Console.WriteLine(item.Effect[2].Value);
		}

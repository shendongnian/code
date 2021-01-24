							static char UseridText[15] = "userid prop";
							static char propUserid[10] = "user-id";
							static char toText[10] = "to prop";
							static char propTo[10] = "to";
							if (Map_AddOrUpdate(propMap, propTo, toText) != MAP_OK)
							{
								(void)printf("ERROR: Map_AddOrUpdate Failed!\r\n");
							}
							if (Map_AddOrUpdate(propMap, propUserid, UseridText) != MAP_OK)
							{
								(void)printf("ERROR: Map_AddOrUpdate Failed!\r\n");
							}

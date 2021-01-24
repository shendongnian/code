        ///<summary>
        ///Extracts the properties of the supplied type that are to be displayed
		///<para>The type must be a class or an InvalidOperationException will be thrown</para>
		///</summary>
        public Virtualiser(Type t)
        {
			if (!t.IsClass)
				throw new InvalidOperationException("Supplied type is not a class");
			List<VirtualColumnInfo> definedColumns = new List<VirtualColumnInfo>();
            PropertyInfo[] ps = t.GetProperties();
			MethodInfo mg, ms;
            for (int i = 0; i < ps.Length; i++)
            {
				Object[] attr = ps[i].GetCustomAttributes(true);
                if (attr.Length > 0)
                {
					foreach (var a in attr)
                    {
						showColumnAttribute ca = a as showColumnAttribute;
						if (ca != null)
						{
							mg = ps[i].GetGetMethod();
							if (mg != null)
							{
								ms = ps[i].GetSetMethod();
								definedColumns.Add
								(
									new VirtualColumnInfo
									(
										ps[i].Name, ca.Width, ca.ReadOnly, ca.Title == String.Empty ? ps[i].Name : ca.Title, 
										ca.Format, mg, ms
									)
								);
							}
							break;
						}
                    }
				}
            }
			if (definedColumns.Count > 0)
				columns = definedColumns.ToArray();
        }

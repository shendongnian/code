            foreach (var fld in linqTableClass.GetProperties())
            {
                var columnAttribute = fld.CustomAttributes.OfType<ColumnAttribute>()
                                        .SingleOrDefault();
                if (columnAttribute != null)
                {
                    Debug.WriteLine(columnAttribute.Name);
                }
            }

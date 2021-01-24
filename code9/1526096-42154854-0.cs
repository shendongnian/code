     public void SetPropertyX(MyTypedDataRow dataRow, string value)
        {
            var parameter = Expression.Parameter("x", typeof(MyTypedDataRow));
            dataRow.Set(Expression.Lambda<Func<MyTypedDataRow, string>>(Expression.Property(parameter, "PropertyX"), parameter) , value);
        }

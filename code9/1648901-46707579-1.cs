    public void SetInputControlAttributeValue(Field field, string AttributeName, string AttributeValue)
            {
                if (field.ColumnIndex == 1)
                {
                    Control control = inputControls_Column1.FindControl("input" + field.Name);
                    control.GetType().GetProperty(AttributeName).SetValue(control, AttributeValue);
                }
                else if (field.ColumnIndex == 2)
                {
                    Control control = inputControls_Column2.FindControl("input" + field.Name);
                    control.GetType().GetProperty(AttributeName).SetValue(control, AttributeValue);
                }
            }

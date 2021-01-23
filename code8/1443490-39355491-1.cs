    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.ComponentModel;
    public static class EnumerationExtensions
    {
	//This procedure gets the <Description> attribute of an enum constant, if any.
	//Otherwise, it gets the string name of then enum member.
	[Extension()]
	public static string Description(Enum EnumConstant)
	{
		Reflection.FieldInfo fi = EnumConstant.GetType().GetField(EnumConstant.ToString());
		DescriptionAttribute[] attr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
		if (attr.Length > 0) {
			return attr(0).Description;
		} else {
			return EnumConstant.ToString();
		}
	}
    }

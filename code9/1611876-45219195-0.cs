    SortSpan sortSpan = SortSpan.All;                               
    Type type = typeof(SortSpan);
    MemberInfo[] memberInfo = type.GetMember(sortSpan.ToString());
    object[] attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
    string name = ((DisplayAttribute)attributes[0]).Name;

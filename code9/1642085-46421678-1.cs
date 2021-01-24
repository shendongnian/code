    var dataMemberAttribute = memberInfo.GetCustomAttribute<System.Runtime.Serialization.DataMemberAttribute>(false);
    if (dataMemberAttribute!= null) {
        if (!string.IsNullOrEmpty(dataMemberAttribute.Name)) {
            this.Name = dataMemberAttribute.Name;
        }
        this.IsOptional = !dataMemberAttribute.IsRequired;
    }

    var attribute = memberInfo.GetCustomAttribute<TsPropertyAttribute>(false);
    if (attribute != null) {
        if (!string.IsNullOrEmpty(attribute.Name)) {
            this.Name = attribute.Name;
        }
        this.IsOptional = attribute.IsOptional;
    }

        private void CollectErrors()
        {
            Errors.Clear();
            PropertyInfos.ForEach(
                prop =>
                {
                    var currentValue = prop.GetValue(this);
                    var requiredAttr = prop.GetCustomAttribute<RequiredAttribute>();
                    var maxLenAttr = prop.GetCustomAttribute<MaxLengthAttribute>();
                    var regexAttr = prop.GetCustomAttribute<RegularExpressionAttribute>();
                    if (requiredAttr != null)
                        if (string.IsNullOrEmpty(currentValue?.ToString() ?? string.Empty))
                            Errors.Add(prop.Name, requiredAttr.ErrorMessage);
                    if (maxLenAttr != null)
                        if ((currentValue?.ToString() ?? string.Empty).Length > maxLenAttr.Length)
                            Errors.Add(prop.Name, maxLenAttr.ErrorMessage);
                    if (regexAttr != null)
                        if (!regexAttr.IsValid((currentValue?.ToString() ?? string.Empty)))
                            Errors.Add(prop.Name, regexAttr.ErrorMessage);
                });
            OnPropertyChanged(nameof(HasErrors));
            OnPropertyChanged(nameof(IsOk));
            OnErrorsCollected();
        }

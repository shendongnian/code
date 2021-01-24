    if (oDE.Properties.Contains(sPropertyName))
    {
        oDE.Properties[sPropertyName].Value = sPropertyValue;
    }
    else
    {
        //The following line will never work in this context
        oDE.Properties[sPropertyName].Add(sPropertyValue);
    }

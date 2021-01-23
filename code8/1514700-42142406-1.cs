    private void VerifyPropertyName(string propertyName)
    {
      if (GetType().GetRuntimeProperty(propertyName) != null) {
        // The property is public
      } else if (GetType().GetRuntimeProperties().Any(p => p.Name == propertyName)) {
        // The property is not public, but it exists
      } else {
        // The property does not exist
      }
    }

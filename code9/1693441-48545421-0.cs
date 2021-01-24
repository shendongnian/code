        var props = this.GetProperties();
        foreach (PropertyInfo prop in props) {
            var attrs = prop.GetCustomAttributes(true);
            foreach (object attr in attrs.Where(a => a is ClientAuthenticationAttribute)) {
                var client = ((ClientAuthenticationAttribute)attr).Client;
                // ... do something with client.
            }
        }

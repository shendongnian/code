    using System;
    using System.Text;
    var decodedString = "--W3sic3RhcnRfdGltZSI6IjAiLCJwcm9kdWN0X2lkIjoiODQwMDMzMDQiLCJ1cmwiOiIifSx7InN0YXJ0X3RpbWUiOiI3OSIsInByb2R1Y3RfaWQiOiI4NDAzNjk2MSIsInVybCI6IiJ9LHsic3RhcnRfdGltZSI6IjgyIiwicHJvZHVjdF9pZCI6Ijg0MDAzMDIwIiwidXJsIjoiIn0seyJzdGFydF90aW1lIjoiMTA5IiwicHJvZHVjdF9pZCI6IiIsInVybCI6Imh0dHBzOi8vYmxvZy5sYXJlaW5lZHVzaG9wcGluZy5jYS8yMDE3LzAxL3RyYW5zZm9ybWVyLXNlcy12aWV1eC1nYW50cy1kZS1jdWlyLWVuLTUtbWludXRlcy8ifV0="
        .Replace("-", "");
    var bytes = Convert.FromBase64String(decodedString);
    var encodedString = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(encodedString);

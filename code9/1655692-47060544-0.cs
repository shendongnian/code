    public class MyConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty(name: "myProperty")]
        public TestEnum MyProperty => 
            (TestEnum) Enum.Parse(typeof(TestEnum), Convert.ToString(base["myProperty"]));
    }
    public enum TestEnum
    {
        A = 1, B = 2
    }
    <?xml version="1.0" encoding="utf-8" ?>
    <configuration>
      <configSections>
        <section name="myConfigurationSection" 
                 type="ValidatedConfigurationSection.MyConfigurationSection,
                       ValidatedConfigurationSection"/>
      </configSections>
      <myConfigurationSection myProperty="NoSuchValueInEnum"/>
    </configuration>

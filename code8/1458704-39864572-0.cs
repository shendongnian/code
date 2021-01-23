	class MySetting : System.Configuration.ApplicationSettingsBase
	{
		[UserScopedSettingAttribute]
		[DefaultSettingValueAttribute("Overflow")]
		public String Stack
		{
 			get { return (String)this["Stack"]; }
			set { this["Stack"] = value; }
		}
	}

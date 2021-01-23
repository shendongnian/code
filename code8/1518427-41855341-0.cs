    		m_FacebookVersion = "N/A";
			Type myType = Type.GetType("Facebook.Unity.FacebookSdkVersion, Assembly-CSharp");
			if(myType != null)
			{
				PropertyInfo myProp = myType.GetProperty("Build");
				if(myProp != null)
				{
					m_FacebookVersion = (string)myProp.GetValue(null, null);
				}
			}

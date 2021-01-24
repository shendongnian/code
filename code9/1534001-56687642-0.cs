<link rel="icon" type="image/png" sizes="923x923" href=@Shared.GetFavIcon() />
It's a big icon I know, but the browsers get it shrunk down to the size needed for the platform.
Shared.cs
public static class Shared
	{
		private static OverallStatusEnum overallStatus;
		public static string GetFavIcon()
		{
			switch (overallStatus)
			{
				case OverallStatusEnum.Ok:
					return "https://PathToServer/Green.png";
				case OverallStatusEnum.Warning:
					return "https://PathToServer/Yellow.png";
				case OverallStatusEnum.Error:
					return "https://PathToServer/Red.png";
				default:
					return "https://PathToServer/Yellow.png";
			}
		}
		public static class Status
		{
			private static OverallStatusEnum apiStatus;
			private static OverallStatusEnum criticalServicesStatus;
			// When adding a new section to monitor, add the overall status here so the favicon can be updated
			public static OverallStatusEnum ApiStatus { get => apiStatus; set => UpdateStatus(value, nameof(ApiStatus)); }
			public static OverallStatusEnum CriticalServicesStatus { get => criticalServicesStatus; set => UpdateStatus(value, nameof(CriticalServicesStatus)); }
			private static void UpdateStatus(OverallStatusEnum status, string propertyName)
			{
				switch(propertyName)
				{
					case nameof(ApiStatus):
						apiStatus = status;
						break;
					case nameof(CriticalServicesStatus):
						criticalServicesStatus = status;
						break;
				}
				overallStatus = (OverallStatusEnum)GetHighestStatusLevel();
			}
			private static int GetHighestStatusLevel()
			{
				var highestLevel = -1;
				var type = typeof(Status);
				foreach (var p in type.GetFields(BindingFlags.Static | BindingFlags.NonPublic))
				{
					var v = p.GetValue(null); // static classes cannot be instanced, so use null...
					if (highestLevel > (int)v || highestLevel == (int)v)
						continue;
					highestLevel = (int)v;
				}
				return highestLevel;
			}
		}
	}
OverallStatusEnum
public enum OverallStatusEnum
		{
			Ok,
			Warning,
			Error
		}

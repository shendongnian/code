csharp
using System;
using System.Runtime.InteropServices;
TimeZoneInfo easternStandardTime;
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
  easternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
}
if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
  easternStandardTime = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
}
if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
  throw new NotImplementedException($"I don't know how to do a lookup on a Mac.");
}

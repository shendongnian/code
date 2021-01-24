    private static ExtendedPropertyDefinition CreateOnlineMeetingProperty()
            {
                ExtendedPropertyDefinition extendedUCMeetingSetting =
                    new ExtendedPropertyDefinition(new Guid("{00020329-0000-0000-C000-000000000046}"), "UCMeetingSetting",
                        MapiPropertyType.String);
    
                return extendedUCMeetingSetting;
            }

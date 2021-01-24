    appointment = FindOrganizerAppointment(appointment);
    
    /// <summary>
    /// Finds the related Appointment.
    /// </summary>
    /// <param name="appointment">The appointment whose original is to be found.</param>
    /// <returns></returns>
    private Appointment FindOrganizerAppointment(Appointment appointment)
    {
        try
        {
            Impersonate(appointment.Organizer.Address);
            var filter = new SearchFilter.IsEqualTo
            {
                PropertyDefinition = new ExtendedPropertyDefinition
                    (DefaultExtendedPropertySet.Meeting, 0x03, MapiPropertyType.Binary),
                Value = GetObjectIdStringFromUid(appointment.ICalUid)
            };
            var view = new ItemView(1) { PropertySet = new PropertySet(BasePropertySet.FirstClassProperties) };
            return _service.FindItems(WellKnownFolderName.Calendar, filter, view).Items[0] as Appointment;
        }
        catch (Exception e)
        {
             throw e;
        }
        finally
        {
            DisableImpersonation();
        }
    }
    /// <summary>
    /// Gets the object id string from uid.
    /// <remarks>The UID is formatted as a hex-string and the GlobalObjectId is displayed as a Base64 string.</remarks>
    /// </summary>
    /// <param name="id">The uid.</param>
    /// <returns></returns>
    private static string GetObjectIdStringFromUid(string id)
    {
        var buffer = new byte[id.Length / 2];
        for (int i = 0; i < id.Length / 2; i++)
        {
            var hexValue = byte.Parse(id.Substring(i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            buffer[i] = hexValue;
        }
        return Convert.ToBase64String(buffer);
    }

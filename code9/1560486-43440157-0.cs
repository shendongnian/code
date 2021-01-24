    query = query
    .Where(j =>
        j.HospitalDepartments.Any(jj =>
            jj.Units.Any(m =>
                m.Devices.All(
                    w => selectedDeviceTypeIDs.Contains(w.DeviceTypeID))
                &&
                selectedDeviceTypeIDs.All(
                    g => m.Devices.Select(d => d.DeviceTypeID).Contains(g))
            )
        )
    );

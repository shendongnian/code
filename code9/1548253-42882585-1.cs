    public void ApplyFamilyPermissions(Family family, UserEntity user)
    {
        foreach (var property in family.LimitedProperties) {
            if (property.ReadPriviledges.Intersect(user.Priviledges).Any() == false) {
                 family.LimitedProperties.Remove(property);
            } else if (property.IsReadOnly == false && HasPropertyWriteAccess(property, user) == false) {
                 property.MakeReadOnly();
            }
        }
    }

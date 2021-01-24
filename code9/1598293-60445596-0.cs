    public int NewProperty(PropertyData propertyData)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("InsertUpdateProperty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", propertyData.ID);
                cmd.Parameters.AddWithValue("@ListPropertyFor", propertyData.ListPropertyFor);
                cmd.Parameters.AddWithValue("@PropertyTypeId", propertyData.PropertyTypeId);
                cmd.Parameters.AddWithValue("@PropertyLoction", propertyData.PropertyLocation);
                cmd.Parameters.AddWithValue("@Locality", propertyData.Locality);
                cmd.Parameters.AddWithValue("@ProjectName", propertyData.ProjectName);
                cmd.Parameters.AddWithValue("@PropertyDescription", propertyData.PropertyDescription);
                cmd.Parameters.AddWithValue("@SuperBulidupArea", propertyData.SuperBulidupArea);
                cmd.Parameters.AddWithValue("@SuperBulidupId", propertyData.SuperBulidupAreaId);
                cmd.Parameters.AddWithValue("@BulidupArea", propertyData.BulidupArea);
                cmd.Parameters.AddWithValue("@BulidupAreaId", propertyData.BulidupAreaId);
                cmd.Parameters.AddWithValue("@CarpetArea", propertyData.CarpetArea);
                cmd.Parameters.AddWithValue("@CarpetAreaId", propertyData.CarpetAreaId);
                cmd.Parameters.AddWithValue("@Bathrooms", propertyData.Bathrooms);
                cmd.Parameters.AddWithValue("@Bedrooms", propertyData.Bedrooms);
                cmd.Parameters.AddWithValue("@Balconies", propertyData.Balconies);
                cmd.Parameters.AddWithValue("@FurnishedId", propertyData.FurnishedId);
                cmd.Parameters.AddWithValue("@TotalFloors", propertyData.TotalFloors);
                cmd.Parameters.AddWithValue("@PropertyOnFloors", propertyData.PropertyOnFloor);
                cmd.Parameters.AddWithValue("@Parking", propertyData.Parking);
                cmd.Parameters.AddWithValue("@AvalibiltyId", propertyData.AvalibiltyId);
                cmd.Parameters.AddWithValue("@AgeOfProperty", propertyData.AgeOfProperty);
                cmd.Parameters.AddWithValue("@OwnerShip", propertyData.OwenerShip);
                cmd.Parameters.AddWithValue("@Price", propertyData.Price);
                cmd.Parameters.AddWithValue("@IsActive", propertyData.IsActive);
                con.Open();
                int i = Convert.ToInt32(cmd.ExecuteScalar()); 
                con.Close();
                return i;
            }
        }

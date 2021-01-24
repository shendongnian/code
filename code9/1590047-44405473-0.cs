     using (MySqlConnection connection = new MySqlConnection(sqlConnString.GetConnectionString(true)))
            {
                connection.Open();
                string SQLString = @"INSERT INTO account_components 
                                    (accountID,shapeMother,shapeFather,skinMother,skinFather,shapeMix,skinMix,
                                    eyeColor,eyeBrows,lipstick,lipstickColor,beard,beardColor,
                                    hair,hairColor) VALUES
                                    ('" + _acc.Id + "'," +
                                    "'" + _acc.Character.ShapeMother + "'," +
                                    "'" + _acc.Character.ShapeFather + "'," +
                                    "'" + _acc.Character.SkinMother + "'," +
                                    "'" + _acc.Character.SkinFather + "'," +
                                    "'@ShapeMix'," +
                                    "'@SkinMix'," +
                                    "'" + _acc.Character.EyeColor + "'," +
                                    "'" + _acc.Character.EyeBrows + "'," +
                                    "'" + _acc.Character.Lipstick + "'," +
                                    "'" + _acc.Character.LipstickColor + "'," +
                                    "'" + _acc.Character.Beard + "'," +
                                    "'" + _acc.Character.BeardColor + "'," +
                                    "'" + _acc.Character.Hair + "'," +
                                    "'" + _acc.Character.HairColor + "')";
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    cmd.Parameters.Add("ShapeMix", MySqlDbType.Float).Value = 0.5f; //_acc.Character.ShapeMix;
                    cmd.Parameters.Add("SkinMix", MySqlDbType.Float).Value = 0.5f; //_acc.Character.SkinMix;
                    cmd.ExecuteNonQuery();
                }
            } //connection closed and disposed here
        }

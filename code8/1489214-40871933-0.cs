            Array cornerValues = Enum.GetValues(typeof(Corner));
            Array faceletValues = Enum.GetValues(typeof(Facelet));
            foreach (Corner i in cornerValues)
            {
                int cornerOrdinal = Array.IndexOf(cornerValues, i);
                for (byte ori = 0; ori < 3; ori++)
                {
                    Facelet currentCornerFacelet = cornerFacelet[cornerOrdinal][ori];
                    int faceletOrdinal = Array.IndexOf(faceletValues, currentCornerFacelet);
                    if (f[faceletOrdinal] == color.U || f[faceletOrdinal] == color.D)
                    {
                        break;
                    }
                }
            }

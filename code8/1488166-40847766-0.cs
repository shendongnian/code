            using (var rs = rdr.GetStream(rdr.GetOrdinal("data")))
            {
                rs.CopyTo(mm);
            }
            h = mm.ToArray();
        }

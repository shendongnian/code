        private bool DBValidCheck(string connection)
        {
            //Using statement releases the object that implement iDisposable once it exits the block. Takes care of the dispose
            using (var connection = new SqlConnection(connection))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private bool CheckHeader(dynamic Request, ref object Response)
        {
            //Response variable should stay there since it might be a
            //breaking change, you should check if you can remove it
            if (Request.Header == null)
            {
                throw new System.ArgumentException("Header Object not found");
            }
            return true;
        }

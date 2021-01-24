            ObjectParameter statusCode = new ObjectParameter("StatusCode", typeof(int));
            ObjectParameter statusMessage = new ObjectParameter("StatusMessage", typeof(string));
            return Context.p_Currencies_List(userName, statusCode, statusMessage).Distinct().Select(c => new Countries_List_ResultModel()
            {
                currency = c
            }).ToList();

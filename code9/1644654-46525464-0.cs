        public BKG_AOR_CHANGE BKG_AOR_CHANGE_Create(BKG_AOR_CHANGE dto)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add(name: "MEMBER_ORIG_EFF_DT", value: dto.MEMBER_ORIG_EFF_DT, direction: ParameterDirection.Input);
                parameters.Add(name: "MEMBER_ID", value: dto.MEMBER_ID, direction: ParameterDirection.Input);
                parameters.Add(name: "MEMBER_NAME", value: dto.MEMBER_NAME, direction: ParameterDirection.Input);
                parameters.Add(name: "CUSTOMER_TYPE", value: dto.CUSTOMER_TYPE, direction: ParameterDirection.Input);
                parameters.Add(name: "CURR_AGENT_ID", value: dto.CURR_AGENT_ID, direction: ParameterDirection.Input);
                parameters.Add(name: "CURR_AGENT_NAME", value: dto.CURR_AGENT_NAME, direction: ParameterDirection.Input);
                parameters.Add(name: "CURR_AGENCY_ID", value: dto.CURR_AGENCY_ID, direction: ParameterDirection.Input);
                parameters.Add(name: "BKG_AOR_CHANGE_SK", direction: ParameterDirection.Output, size: 31);
                var sql = @"INSERT
                                INTO DS_BROKERAGE.BKG_AOR_CHANGE
                                  (
                                    MEMBER_ORIG_EFF_DT,
                                    MEMBER_ID,
                                    MEMBER_NAME,
                                    CUSTOMER_TYPE,
                                    CURR_AGENT_ID,
                                    CURR_AGENT_NAME,
                                    CURR_AGENCY_ID,
                                  )
                                  VALUES
                                  (
                                    :MEMBER_ORIG_EFF_DT,
                                    :MEMBER_ID,
                                    :MEMBER_NAME,
                                    :CUSTOMER_TYPE,
                                    :CURR_AGENT_ID,
                                    :CURR_AGENT_NAME,
                                    :CURR_AGENCY_ID,
                                  )
								  RETURNING BKG_AOR_CHANGE_SK INTO :BKG_AOR_CHANGE_SK";
								  
                this._db.Execute(sql, parameters);
                dto.BKG_AOR_CHANGE_SK = parameters.Get<int>("BKG_AOR_CHANGE_SK");
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

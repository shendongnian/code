     List<KeyValuePair<string,int>> IWorkflowService.GetServiceRetention()
            {
               var serviceRetention =  from y in _context.SERVICES
                         join z in _context.SERVICE_SETTINGS on y.ID equals z.SERVICEID
                         select new { Service= y.SERVICE, Retention=z.RETENTION };//new KeyValuePair<string,int?>( y.SERVICE, z.RETENTION ));
                var list = new List<KeyValuePair<string, int>>();
                foreach (var obj in serviceRetention)
                {
                    list.Add(new KeyValuePair<string, int>(obj.Service,Convert.ToInt32(obj.Retention)));
                }
                return list;
            }

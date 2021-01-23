             new SQLFunctionTemplate(NHibernateUtil.DateTime, 
                "DateAdd(MINUTE, " + 
                new SQLFunctionTemplate(NHibernateUtil.DateTime,
                    "DateDiff(MINUTE, 0, ?1)"
                ) + 
                ", 0)")

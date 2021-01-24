       Dictionary<string, List<SPFetchCREntity>> objDic = new Dictionary<string, List<SPFetchCREntity>>();
            List<SPFetchCREntity> sp = new List<SPFetchCREntity>();
            foreach (string str in objDic.Keys)
            {
                sp.AddRange(objDic[str]);
            }
           CRmappings2 = new ObservableCollection<SPFetchCREntity>(sp.ToList());
            crentitiesbkp = CollectionViewSource.GetDefaultView(CRmappings2);
        }

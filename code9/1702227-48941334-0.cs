    public class CRCaseMaintExt : PXGraphExtension<CRCaseMaint>
    {
        [Serializable]
        public class CRPrevVersionCase : CRCase
        { }
        public PXSelect<CRPrevVersionCase> PrevVersionCase;
        protected virtual void CRCase_RowSelecting(PXCache sender, PXRowSelectingEventArgs e)
        {
            CRCase row = e.Row as CRCase;
            if (row == null || e.IsReadOnly) return;
            var versionCase = new CRPrevVersionCase();
            var versionCache = PrevVersionCase.Cache;
            sender.RestoreCopy(versionCase, row);
            if (versionCache.Locate(versionCase) == null)
            {
                versionCache.SetStatus(versionCase, PXEntryStatus.Held);
            }
        }
        [PXOverride]
        public void Persist(Action del)
        {
            var origCase = Base.Case.Current;
            var origCache = Base.Case.Cache;
            CRPrevVersionCase versionCase;
            if (origCache.GetStatus(origCase) == PXEntryStatus.Updated)
            {
                versionCase = new CRPrevVersionCase();
                origCache.RestoreCopy(versionCase, origCase);
                versionCase = PrevVersionCase.Cache.Locate(versionCase) as CRPrevVersionCase;
                if (versionCase != null)
                {
                    foreach (var field in Base.Case.Cache.Fields)
                    {
                        if (!Base.Case.Cache.FieldValueEqual(origCase, versionCase, field))
                        {
                            PXTrace.WriteInformation(string.Format(
                                "Field {0} was updated", field));
                        }
                    }
                }
            }
            del();
            if (origCase != null)
            {
                PrevVersionCase.Cache.Clear();
                versionCase = new CRPrevVersionCase();
                Base.Case.Cache.RestoreCopy(versionCase, origCase);
                PrevVersionCase.Cache.SetStatus(versionCase, PXEntryStatus.Held);
            }
        }
    }
    public static class PXCacheExtMethods
    {
        public static bool FieldValueEqual(this PXCache cache, 
            object a, object b, string fieldName)
        {
            return Equals(cache.GetValue(a, fieldName), cache.GetValue(b, fieldName));
        }
    }

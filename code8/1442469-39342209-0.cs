    private void MechanicalPropertiesFilter(SteelNavigatorForm form, ref ITypeSearch<SteelGradeVariantPage> search)
        {
            FilterExpressionParser filterExpressionParser = new FilterExpressionParser(SearchClient.Instance.Conventions);
            Filter combinedFilter = null;
            // Dimension
            if (form.DimensionThickness > 0)
            {
                var dimensionFilter = filterExpressionParser.GetFilter<MechanicalProperties>(m => m.DimensionInMillimeterMin.LessThan(form.DimensionThickness)
                & m.DimensionInMillimeterMax.GreaterThan(form.DimensionThickness));
                combinedFilter = (combinedFilter == null) ? dimensionFilter : combinedFilter & dimensionFilter;
            }
            // Yield strength
            if (form.YieldStrengthMin > 0)
            {
                var yieldStrengthFilter = filterExpressionParser.GetFilter<MechanicalProperties>(m => m.YieldStrengh.GreaterThan(form.YieldStrengthMin));
                combinedFilter = (combinedFilter == null) ? yieldStrengthFilter : combinedFilter & yieldStrengthFilter;
            }
            // Tensile strength
            if (form.TensileStrengthMin > 0 | form.TensileStrengthMax > 0)
            {
                var tensileStrengthMin = (form.TensileStrengthMin == 0) ? double.MinValue : form.TensileStrengthMin;
                var tensileStrengthMax = (form.TensileStrengthMax == 0) ? double.MaxValue : form.TensileStrengthMax;
                var tensileStrengthFilter = filterExpressionParser.GetFilter<MechanicalProperties>(m => m.TensileStrengthMin.InRangeInclusive(tensileStrengthMin, tensileStrengthMax) | m.TensileStrengthMax.InRangeInclusive(tensileStrengthMin, tensileStrengthMax));
                combinedFilter = (combinedFilter == null) ? tensileStrengthFilter : combinedFilter & tensileStrengthFilter;
            }
            // Elongation
            if (form.Elongation > 0)
            {
                var elongationFilter = filterExpressionParser.GetFilter<MechanicalProperties>(m => m.ElongationA5Percentage.GreaterThan(form.Elongation));
                combinedFilter = (combinedFilter == null) ? elongationFilter : combinedFilter & elongationFilter;
            }
            // Hardness
            if (form.HardnessMin > 0 || form.HardnessMax > 0)
            {
                var max = (form.HardnessMax == 0) ? double.MaxValue : form.HardnessMax;
                var hardnessFilter = filterExpressionParser.GetFilter<MechanicalProperties>(m => m.HardnessScaleGuid.Match(form.HardnessMethod) & (
                    m.HardnessMin.InRangeInclusive(form.HardnessMin, max)
                    | m.HardnessMax.InRangeInclusive(form.HardnessMin, max)));
                combinedFilter = (combinedFilter == null) ? hardnessFilter : combinedFilter & hardnessFilter;
            }
            if (combinedFilter != null)
            {
                NestedFilterExpression<SteelGradeVariantPage, MechanicalProperties> mechanicalFilterExpression = new NestedFilterExpression<SteelGradeVariantPage, MechanicalProperties>(v => v.MechanicalProperties, ((MechanicalProperties item) => combinedFilter), search.Client.Conventions);
         
                search = search.Filter(mechanicalFilterExpression.NestedFilter);
            }
        }

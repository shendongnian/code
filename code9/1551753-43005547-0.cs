    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using Telerik.WinControls.Data;
    using Telerik.WinControls.UI;
    
    namespace MySoftware.Helpers
    {
        internal static class RadGridViewHelper
        {
            private class CustomStringFilteringClass
            {
                private RadGridView RadGridView { get; }
                private bool _enabled;
                private ReadOnlyCollection<string> StringColumns { get; }
    
                public CustomStringFilteringClass(RadGridView radGridView)
                {
                    RadGridView = radGridView;
                    StringColumns = new ReadOnlyCollection<string>(GetStringColumns(radGridView));
                }
    
                public void Enable()
                {
                    if (_enabled) throw new InvalidOperationException("Can't call this method twice");
                    _enabled = true;
    
                    RadGridView.EnableCustomFiltering = true;
                    RadGridView.CustomFiltering += RadGridViewOnCustomFiltering;
                }
    
                private void RadGridViewOnCustomFiltering(object sender, GridViewCustomFilteringEventArgs e)
                {
                    if (RadGridView.FilterDescriptors.Count == 0) return;
    
                    var row = e.Row;
    
                    foreach (var stringColumn in StringColumns)
                    {
                        var filterDescriptors = RadGridView.FilterDescriptors.Where(
                            x => x.PropertyName == stringColumn).ToList();
                        if (filterDescriptors.Count != 1)
                        {
                            continue;
                        }
                        var filterDescriptor = filterDescriptors.First();
                        var cellValue = ((string) row.Cells[stringColumn].Value).ToLowerInvariant();
                        if (filterDescriptor.GetType() == typeof(CompositeFilterDescriptor))
                        {
                            if (!CompositeFilterEvaluateString((CompositeFilterDescriptor) filterDescriptor, cellValue,
                                RadGridView.MasterTemplate.DataView.FilterEvaluate, row))
                            {
                                e.Visible = false;
                                return;
                            }
                        }
                        else if (!FilterEvaluateString(filterDescriptor, cellValue,
                            RadGridView.MasterTemplate.DataView.FilterEvaluate, row))
                        {
                            e.Visible = false;
                            return;
                        }
                    }
    
                    var nonStringFilterDescriptors = RadGridView.FilterDescriptors.Where(
                        x => !StringColumns.Contains(x.PropertyName));
                    foreach (var filterDescriptor in nonStringFilterDescriptors)
                    {
                        if (!RadGridView.MasterTemplate.DataView.FilterEvaluate(filterDescriptor, row))
                        {
                            e.Visible = false;
                            return;
                        }
                    }
                }
    
                private static bool CompositeFilterEvaluateString(CompositeFilterDescriptor compositeFilterDescriptor,
                    string cellValue, Func<FilterDescriptor, GridViewRowInfo, bool> gridFilterEvaluate, GridViewRowInfo row)
                {
                    switch (compositeFilterDescriptor.LogicalOperator)
                    {
                        case FilterLogicalOperator.And:
                            if (compositeFilterDescriptor.FilterDescriptors.Any(filterDescriptor =>
                            {
                                if (filterDescriptor.GetType() == typeof(CompositeFilterDescriptor))
                                    return !CompositeFilterEvaluateString((CompositeFilterDescriptor) filterDescriptor,
                                        cellValue, gridFilterEvaluate, row);
                                return !FilterEvaluateString(filterDescriptor, cellValue, gridFilterEvaluate, row);
                            }))
                                return false;
                            break;
                        case FilterLogicalOperator.Or:
                            if (compositeFilterDescriptor.FilterDescriptors.All(filterDescriptor =>
                            {
                                if (filterDescriptor.GetType() == typeof(CompositeFilterDescriptor))
                                    return !CompositeFilterEvaluateString((CompositeFilterDescriptor) filterDescriptor,
                                        cellValue, gridFilterEvaluate, row);
                                return !FilterEvaluateString(filterDescriptor, cellValue, gridFilterEvaluate, row);
                            }))
                                return false;
                            break;
                    }
                    return true;
                }
    
                private static bool FilterEvaluateString(FilterDescriptor filterDescriptor, string cellValue,
                    Func<FilterDescriptor, GridViewRowInfo, bool> gridFilterEvaluate, GridViewRowInfo row)
                {
                    var filterDescriptorValue = ((string) filterDescriptor.Value).ToLowerInvariant();
                    switch (filterDescriptor.Operator)
                    {
                        case FilterOperator.Contains:
                            if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(cellValue, filterDescriptorValue,
                                    CompareOptions.IgnoreNonSpace) == -1)
                                return false;
                            break;
                        case FilterOperator.NotContains:
                            if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(cellValue, filterDescriptorValue,
                                    CompareOptions.IgnoreNonSpace) != -1)
                                return false;
                            break;
                        case FilterOperator.StartsWith:
                            if (!CultureInfo.InvariantCulture.CompareInfo.IsPrefix(cellValue, filterDescriptorValue,
                                CompareOptions.IgnoreNonSpace))
                                return false;
                            break;
                        case FilterOperator.EndsWith:
                            if (!CultureInfo.InvariantCulture.CompareInfo.IsSuffix(cellValue, filterDescriptorValue,
                                CompareOptions.IgnoreNonSpace))
                                return false;
                            break;
                        case FilterOperator.IsEqualTo:
                            if (String.Compare(cellValue, filterDescriptorValue, CultureInfo.InvariantCulture,
                                    CompareOptions.IgnoreNonSpace) != 0)
                                return false;
                            break;
                        case FilterOperator.IsNotEqualTo:
                            if (String.Compare(cellValue, filterDescriptorValue, CultureInfo.InvariantCulture,
                                    CompareOptions.IgnoreNonSpace) == 0)
                                return false;
                            break;
                        default:
                            if (!gridFilterEvaluate.Invoke(filterDescriptor, row))
                                return false;
                            break;
                    }
                    return true;
                }
            }
    
            private static List<string> GetStringColumns(RadGridView radGridView)
            {
                var retVal = new List<string>();
                foreach (var column in radGridView.Columns)
                {
                    if (column.DataType == typeof(string))
                    {
                        retVal.Add(column.Name);
                    }
                }
                return retVal;
            }
    
            /// <summary>
            /// Enables custom string filtering on <paramref name="radGridView"/>. It is case insensitive and
            /// tolerates differences in diacritical marks. For example, in a "equals" comparision, the value
            /// 'ëMúa' is treated as its equal to 'EmÜâ'.
            /// </summary>
            /// <param name="radGridView">Instance of <see cref="RadGridView"/> in which custom string filtering
            /// will be enabled.</param>
            public static void CustomStringFiltering(RadGridView radGridView)
            {
                var customFiltering = new CustomStringFilteringClass(radGridView);
                customFiltering.Enable();
            }
        }
    }

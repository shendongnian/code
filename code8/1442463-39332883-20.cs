    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using LambdaSample.Framework;
    using LambdaSample.Interfaces;
    using LinqKit;
    namespace LambdaSample.Extensions
    {
        public static class ExpressionExtensions
        {
            private static readonly MethodInfo StringContainsMethod = typeof(string).GetMethod(@"Contains", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
            private static readonly MethodInfo StringStartsWithMethod = typeof(string).GetMethod(@"StartsWith", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
            private static readonly MethodInfo StringEndsWithMethod = typeof(string).GetMethod(@"EndsWith", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(string) }, null);
            private static readonly MethodInfo ObjectEquals = typeof(object).GetMethod(@"Equals", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(object) }, null);
            //private static readonly MethodInfo BooleanEqualsMethod = typeof(bool).GetMethod(@"Equals", BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(bool) }, null);
            /// <summary>
            /// Build a predicate with linq clauses, taking searchCriteria object's properties to define where conditions.
            /// </summary>
            /// <typeparam name="TDbType">Type of entity to build predicate for</typeparam>
            /// <param name="searchCriteria">Object which contains criteria for predicate</param>
            /// <param name="predicateParser">Implementation of predicate parser that will parse predicates as string</param>
            /// <param name="includeNullValues">Determines whether null values are included when constructing query</param>
            /// <returns></returns>
            public static Expression<Func<TDbType, bool>> BuildPredicate<TDbType>(object searchCriteria, IPredicateParser predicateParser, bool includeNullValues)
            {
                var filterDictionary = searchCriteria.ToFilterDictionary(includeNullValues);
                return BuildPredicate<TDbType>(filterDictionary, predicateParser);
            }
            public static Expression<Func<TDbType, bool>> BuildPredicate<TDbType>(Dictionary<string, string> searchCriteria, IPredicateParser predicateParser)
            {
                var predicateOuter = PredicateBuilder.New<TDbType>(true);
                var predicateErrorFields = new List<string>();
                var dict = searchCriteria;// as Dictionary<string, string>;
                if (dict == null || !dict.Any())
                    return predicateOuter;
                var searchFields = typeof(TDbType).GetProperties();
                foreach (var searchField in searchFields)
                {
                    // Get the name of the DB field, which may not be the same as the property name.
                    var dbFieldName = GetDbFieldName(searchField);
                    var dbType = typeof(TDbType);
                    var dbFieldMemberInfo = dbType.GetMember(dbFieldName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance).SingleOrDefault();
                    if (dbFieldMemberInfo == null || !dict.ContainsKey(dbFieldMemberInfo.Name))
                        continue;
                    var predicateValue = dict[dbFieldMemberInfo.Name];
                    if (predicateValue == null)
                        continue;
                    var rangesAllowed = searchField.PropertyType != typeof(string);
                    if (!predicateParser.Parse(predicateValue, rangesAllowed, searchField.PropertyType))
                    {
                        predicateErrorFields.Add(dbFieldMemberInfo.Name);
                        continue;
                    }
                    if (!predicateParser.Items.Any())
                        continue;
                    var predicateInner = BuildInnerPredicate<TDbType>(predicateParser, searchField, dbFieldMemberInfo);
                    if (predicateInner == null)
                        continue;
                    predicateOuter = predicateOuter.And(predicateInner);
                }
                return predicateOuter;
            }
            private static Expression<Func<TDbType, bool>> BuildInnerPredicate<TDbType>(IPredicateParser predicateParser, PropertyInfo searchField, MemberInfo dbFieldMemberInfo)
            {
                var dbType = typeof(TDbType);
                // Create an "x" as TDbType
                var dbTypeParameter = Expression.Parameter(dbType, @"x");
                // Get at x.firstName
                var dbFieldMember = Expression.MakeMemberAccess(dbTypeParameter, dbFieldMemberInfo);
                Expression<Func<TDbType, bool>> predicateInner = null;
                foreach (var predicateItem in predicateParser.Items)
                {
                    var predicateItemSingle = predicateItem as PredicateItemSingle;
                    var predicateItemRange = predicateItem as PredicateItemRange;
                    if (predicateItemSingle != null)
                    {
                        // Create the MethodCallExpression like x.firstName.Contains(criterion)
                        if (searchField.PropertyType == typeof(string))
                        {
                            var str = predicateItemSingle.Value as string ?? "";
                            var startsWithAsterisk = str.StartsWith("*");
                            var endsWithAsterisk = str.EndsWith("*");
                            str = str.Trim('*').Trim();
                            MethodCallExpression callExpression;
                            if (startsWithAsterisk && !endsWithAsterisk)
                            {
                                callExpression = Expression.Call(dbFieldMember, StringEndsWithMethod, new Expression[] { Expression.Constant(str) });
                            }
                            else if (!startsWithAsterisk && endsWithAsterisk)
                            {
                                callExpression = Expression.Call(dbFieldMember, StringStartsWithMethod, new Expression[] { Expression.Constant(str) });
                            }
                            else
                            {
                                callExpression = Expression.Call(dbFieldMember, StringContainsMethod, new Expression[] { Expression.Constant(str) });
                            }
                            predicateInner = (predicateInner ?? PredicateBuilder.New<TDbType>(false)).Or(Expression.Lambda(callExpression, dbTypeParameter) as Expression<Func<TDbType, bool>>);
                        }
                        else
                        {
                            if (dbFieldMember.Type.IsEnum)
                            {
                                if (!dbFieldMember.Type.IsEnumDefined(predicateItemSingle.Value))
                                    continue;
                                var enumValue = (int)predicateItemSingle.Value;
                                if (enumValue <= 0)
                                    continue;
                                var enumObj = Enum.ToObject(dbFieldMember.Type, (int)predicateItemSingle.Value);
                                predicateInner = (predicateInner ?? PredicateBuilder.New<TDbType>(false)).Or(Expression.Lambda<Func<TDbType, bool>>(Expression.Equal(dbFieldMember, Expression.Constant(enumObj)), new[] { dbTypeParameter }));
                            }
                            else
                            {
                                predicateInner = (predicateInner ?? PredicateBuilder.New<TDbType>(false)).Or(Expression.Lambda<Func<TDbType, bool>>(Expression.Equal(dbFieldMember, Expression.Constant(predicateItemSingle.Value)), new[] { dbTypeParameter }));
                            }
                        }
                    }
                    else if (predicateItemRange != null)
                    {
                        var predicateRange = PredicateBuilder.New<TDbType>(true);
                        predicateRange = predicateRange.And(Expression.Lambda<Func<TDbType, bool>>(Expression.GreaterThanOrEqual(dbFieldMember, Expression.Constant(predicateItemRange.Value1)), new[] { dbTypeParameter }));
                        predicateRange = predicateRange.And(Expression.Lambda<Func<TDbType, bool>>(Expression.LessThanOrEqual(dbFieldMember, Expression.Constant(predicateItemRange.Value2)), new[] { dbTypeParameter }));
                        predicateInner = (predicateInner ?? PredicateBuilder.New<TDbType>(false)).Or(predicateRange);
                    }
                }
                return predicateInner;
            }
            private static string GetDbFieldName(PropertyInfo propertyInfo)
            {
                var dbFieldName = propertyInfo.Name;
                // TODO: Can put custom logic here, to obtain another field name if desired.
                return dbFieldName;
            }
        }
    }

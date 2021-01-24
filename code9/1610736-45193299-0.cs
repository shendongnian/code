    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace AgentOctal.WpfLib
    {
        public class PropertyChangeCascade<T> where T : ObservableObject
        {
    
            public PropertyChangeCascade(ObservableObject target)
            {
                Target = target;
    
                Target.PropertyChanged += PropertyChangedHandler;
                _cascadeInfo = new Dictionary<string, List<string>>();
            }
    
            public ObservableObject Target { get; }
            public bool PreventLoops { get; set; } = false;
    
            private Dictionary<string, List<string>> _cascadeInfo;
    
            public PropertyChangeCascade<T> AddCascade(string sourceProperty,
                                                       List<string> targetProperties)
            {
                List<string> cascadeList = null;
    
                if (!_cascadeInfo.TryGetValue(sourceProperty, out cascadeList))
                {
                    cascadeList = new List<string>();
                    _cascadeInfo.Add(sourceProperty, cascadeList);
                }
    
                cascadeList.AddRange(targetProperties);
    
                return this;
            }
    
            public PropertyChangeCascade<T> AddCascade(Expression<Func<T, object>> sourceProperty,
                                                       Expression<Func<T, object>> targetProperties)
            {
                string sourceName = null;
                var lambda = (LambdaExpression)sourceProperty;
    
                if (lambda.Body is MemberExpression expressionS)
                {
                    sourceName = expressionS.Member.Name;
                }
                else if (lambda.Body is UnaryExpression unaryExpression)
                {
                    sourceName = ((MemberExpression)unaryExpression.Operand).Member.Name;
                }
                else
                {
                    throw new ArgumentException("sourceProperty must be a single property", nameof(sourceProperty));
                }
    
                var targetNames = new List<string>();
                lambda = (LambdaExpression)targetProperties;
    
                if (lambda.Body is MemberExpression expression)
                {
                    targetNames.Add(expression.Member.Name);
                }
                else if (lambda.Body is UnaryExpression unaryExpression)
                {
                    targetNames.Add(((MemberExpression)unaryExpression.Operand).Member.Name);
                }
                else if (lambda.Body.NodeType == ExpressionType.New)
                {
                    var newExp = (NewExpression)lambda.Body;
                    foreach (var exp in newExp.Arguments.Select(argument => argument as MemberExpression))
                    {
                        if (exp != null)
                        {
                            var mExp = exp;
                            targetNames.Add(mExp.Member.Name);
                        }
                        else
                        {
                            throw new ArgumentException("Syntax Error: targetProperties has to be an expression " +
                                                        "that returns a new object containing a list of " +
                                                        "properties, e.g.: s => new { s.Property1, s.Property2 }");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Syntax Error: targetProperties has to be an expression " +
                                                "that returns a new object containing a list of " +
                                                "properties, e.g.: s => new { s.Property1, s.Property2 }");
                }
    
                return AddCascade(sourceName, targetNames);
            }
    
            public void Detach()
            {
                Target.PropertyChanged -= PropertyChangedHandler;
            }
    
            private void PropertyChangedHandler(object sender, PropertyChangedEventArgs e)
            {
                List<string> cascadeList = null;
    
                if (_cascadeInfo.TryGetValue(e.PropertyName, out cascadeList))
                {
                    if (PreventLoops)
                    {
                        var cascaded = new HashSet<string>();
                        cascadeList.ForEach(cascadeTo =>
                        {
                            if (!cascaded.Contains(cascadeTo))
                            {
                                cascaded.Add(cascadeTo);
                                Target.RaisePropertyChanged(cascadeTo);
                            }
                        });
                    }
                    else
                    {
                        cascadeList.ForEach(cascadeTo =>
                        {
                            Target.RaisePropertyChanged(cascadeTo);
                        });
                    }
                }
            }
        }
    }

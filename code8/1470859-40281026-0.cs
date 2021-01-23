                case ExpressionType.Conditional:
                    var ce = expr.Body as ConditionalExpression;
                    var cond = (MemberExpression)ce.Test;
                    me = (MemberExpression) (ce != null && (bool)(Expression.Lambda(cond).Compile().DynamicInvoke()) ? ce.IfTrue : ce.IfFalse); 
                    break;

    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Reestr.DAL.DB;
    using Reestr.DAL.DataAnnotations;
    using Reestr.DAL.Entities;
    using ServiceStack.DataAnnotations;
    using ServiceStack.OrmLite;
    
    namespace Reestr.DAL.Helpers
    {
        /// <summary>
        /// Класс для обработки входящего предиката на предмет генерации новых предикатов и выделения вложенных предикатов
        /// </summary>
        internal class MethodFinder : ExpressionVisitor
        {
            private Expression reGenNode;
            // not best solution to put into this class this object...but...crutch variant
            private ReestrContext db;
    
            public MethodFinder(ReestrContext _db)
            {
                db = _db;
                IsNestedPocoExist = false;
            }
    
            public void DoVisiting(Expression node)
            {
                reGenNode = Visit(node);
            }
    
            /// <summary>
            /// Получает значение указывающее, что есть вложенные POCO объекты
            /// </summary>
            public bool IsNestedPocoExist { get; private set; }
            
            /// <summary>
            /// Получает новосгенерированный предикат, без использования вложенных предикатов
            /// </summary>
            /// <returns></returns>
            public Expression<Func<T,bool>> GetRegeneratedPredicate<T>()
            {
                LambdaExpression le = reGenNode as LambdaExpression;
                return Expression.Lambda<Func<T, bool>>(le.Body, le.Parameters);
            }
    
            /// <summary>
            /// Просматривает дочерний элемент выражения <see cref="T:System.Linq.Expressions.MethodCallExpression"/>.
            /// </summary>
            /// <returns>
            /// Измененное выражение в случае изменения самого выражения или любого его подвыражения; в противном случае возвращается исходное выражение.
            /// </returns>
            /// <param name="node">Выражение, которое необходимо просмотреть.</param>
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                // статический метод расширения, возвращающий bool
                if (node.Object == null && node.Method.IsGenericMethod && node.Method.ReturnType == typeof (bool))
                {
                    var member = node.Arguments.FirstOrDefault(expression => expression.NodeType == ExpressionType.MemberAccess) as MemberExpression;
                    if (member != null)
                    {
                        var ePrimary = GenPrimaryKeyProperty(member);
                        // получаем вложенную лямбду с рекурсивным проходом
                        foreach (LambdaExpression lambda in node.Arguments.Where(expression => expression.NodeType == ExpressionType.Lambda))
                        {
                            if (lambda.Parameters[0].Type == typeof(Subject))
                            {
                                return GenerateSqlInExpression(ePrimary, lambda, GetFieldLambda<Subject>());
                            }
                            if (lambda.Parameters[0].Type == typeof(Photo))
                            {
                                return GenerateSqlInExpression(ePrimary, lambda, GetFieldLambda<Photo>());
                            }
                            if (lambda.Parameters[0].Type == typeof(Dic))
                            {
                                return GenerateSqlInExpression(ePrimary, lambda, GetFieldLambda<Dic>());
                            }
                        }
                    }
                    // "Вырезаем" вызов метода и заменяем на простейшее условие 1 == 1
                    //return Expression.Equal(Expression.Constant(1), Expression.Constant(1));
                }
    
                // обращение к вложенному POCO типу
                MemberExpression me = node.Object as MemberExpression;
                if (me != null)
                {
                    LambdaExpression lambda = GenLambdaFromMethod(node);
                    if (lambda != null)
                    {
                        Type tExpr = GetInnerPocoExpressionType(me);
                        if (tExpr == typeof(Subject))
                        {
                            return GenerateSqlInExpression(GenPrimaryKeyProperty(me), lambda, GetFieldLambda<Subject>());
                        }
                        if (tExpr == typeof(Photo))
                        {
                            return GenerateSqlInExpression(GenPrimaryKeyProperty(me), lambda, GetFieldLambda<Photo>());
                        }
                        if (tExpr == typeof(Dic))
                        {
                            return GenerateSqlInExpression(GenPrimaryKeyProperty(me), lambda, GetFieldLambda<Dic>());
                        }
                    }
                }
                Visit(node.Arguments);
                return node;
            }
    
            /// <summary>
            /// Получает лямбду из свойства пользовательского типа внутреннего объекта
            /// </summary>
            /// <param name="method"></param>
            /// <returns></returns>
            private LambdaExpression GenLambdaFromMethod(MethodCallExpression method)
            {
                MemberExpression me = method.Object as MemberExpression;
                Type tExpr = GetInnerPocoExpressionType(me);
                ParameterExpression pe = Expression.Parameter(me.Expression.Type, me.Expression.Type.Name.ToLower());
                Expression property = Expression.Property(pe, pe.Type.GetProperties().First(pi => pi.Name == me.Member.Name));
                if (tExpr == typeof (Subject) ||
                    tExpr == typeof(Photo) ||
                    tExpr == typeof(Dic))
                {
                    Expression regenMember = Expression.Call(property, method.Method, method.Arguments);
                    LambdaExpression le = Expression.Lambda(regenMember, pe);
                    return le;
                }
                return null;
            }
    
            /// <summary>
            /// Получает корневой тип объекта
            /// </summary>
            /// <param name="me"></param>
            /// <returns></returns>
            private Type GetInnerPocoExpressionType(MemberExpression me)
            {
                MemberExpression meNested = me.Expression as MemberExpression;
                if (meNested == null)
                {
                    return me.Type;
                }
                return GetInnerPocoExpressionType(meNested);
            }
    
            /// <summary>
            /// Получает последний вложенный POCO объект, например {person} или {dic}, если является свойством POCO класса 
            /// </summary>
            /// <param name="me"></param>
            /// <returns></returns>
            private Expression GetInnerPocoExpression(MemberExpression me)
            {
                MemberExpression meNested = me.Expression as MemberExpression;
                if (meNested == null)
                {
                    return me.Expression;
                }
                return GetInnerPocoExpression(meNested);
            }
    
            /// <summary>
            /// Получаем свойство класса, которое является POCO классом по внешнему ключу например для Person: p => p.Id
            /// </summary>
            /// <param name="me"></param>
            /// <returns></returns>
            private MemberExpression GenPrimaryKeyProperty(MemberExpression me)
            {
                 // POCO выражение
                var mConverted = GetInnerPocoExpression(me);
                // берем свойство с атрибутом PrimaryKey или костыль для типа Subject
                // для предмета у нас не id используется а ChildDicCode (PCode), который является ключом к DicCode таблицы Dic 
                var primaryProperty = mConverted.Type.GetProperties()
                    .FirstOrDefault(info => info.GetCustomAttributes(mConverted.Type == typeof(Subject) ? typeof(CustomPrimaryKeyAttribute) : typeof(PrimaryKeyAttribute), false).Any());
                // формируем обращение к свойству, используя уже имеющийся параметр
                var ePrimary = Expression.Property(mConverted, mConverted.Type.GetProperty(primaryProperty.Name, primaryProperty.PropertyType));
                return ePrimary;
            }
    
            /// <summary>
            /// Возвращает сгенерированную лямбду по внешнему ключу например для Subject: subj => subj.PersonId
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <returns></returns>
            private Expression<Func<T, object>> GetFieldLambda<T>()
            {
                ParameterExpression pePoco = Expression.Parameter(typeof (T), typeof (T).Name.ToLower());
                var referProperty =
                    typeof (T).GetProperties()
                              .FirstOrDefault(
                                  info => info.GetCustomAttributes(typeof (CustomForeignKeyAttribute), false).Any());
                var eReference = Expression.Property(pePoco,
                                                     typeof (T).GetProperty(referProperty.Name, referProperty.PropertyType));
                return Expression.Lambda<Func<T, object>>(Expression.Convert(eReference, typeof (object)), pePoco);
            }
    
            /// <summary>
            /// Возвращает перегенерированную лямбду в виде обращения к статическому методу класса Sql: Sql.In([nested POCO lambda])
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="primary">обращение к свойству POCO объекта</param>
            /// <param name="whereL">сгенерированная лямбда работы с внутренним обїектом</param>
            /// <param name="field">лямба доступа к полю внешнего ключа объекта</param>
            /// <returns></returns>
            private Expression GenerateSqlInExpression<T>(MemberExpression primary, LambdaExpression whereL, Expression<Func<T,object>> field)
            {
                IsNestedPocoExist = true;
                // ищём вложенные лямбды и если нашли добавляем в коллекцию классов новосозданный класс
                var finder = new MethodFinder(db);
                var rebuiltE = finder.Visit(whereL);
                Expression<Func<T, bool>> inWhere = Expression.Lambda<Func<T, bool>>((rebuiltE as LambdaExpression).Body, whereL.Parameters);
                SqlExpression<T> eSqlbody = db.Connection.From<T>().Where(inWhere).SelectDistinct(field);
                MethodInfo mIn = typeof (Sql).GetMethods()
                                             .Where(mi => mi.Name == "In")
                                             .First(mi => mi.GetParameters().Any(pi => pi.ParameterType.Name == typeof (SqlExpression<>).Name))
                                             .MakeGenericMethod(primary.Type, typeof(T));
                return Expression.Call(mIn, primary, Expression.Constant(eSqlbody));
            }
        }
    }

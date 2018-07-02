using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree.MappingExtend
{/// <summary>
/// Cache the expression by the nature of the generic.
/// </summary>
/// <typeparam name="TIn"></typeparam>
/// <typeparam name="TOut"></typeparam>
    public class ExpressionGenericMapper<TIn, TOut>
    {
        /// <summary>
        /// Use a dictionary to cache the expression
        /// </summary>
        //private static Dictionary<string, object> _Dic = new Dictionary<string, object>();
        private static Func<TIn, TOut> _FUNC = null; //If input and output type changed, then create an new instance.

        static ExpressionGenericMapper()
        {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
                List<MemberBinding> memberBindingList = new List<MemberBinding>();
                foreach (var item in typeof(TOut).GetProperties())
                {
                    MemberExpression property = Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                foreach (var item in typeof(TOut).GetFields())
                {
                    MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                    MemberBinding memberBinding = Expression.Bind(item, property);
                    memberBindingList.Add(memberBinding);
                }
                MemberInitExpression memberInitExpression = Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());
                Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression, new ParameterExpression[]
                {
                    parameterExpression
                });
                _FUNC = lambda.Compile();
        }
        public static TOut Trans(TIn tIn)
        {
            return _FUNC(tIn);
        }
    }
}

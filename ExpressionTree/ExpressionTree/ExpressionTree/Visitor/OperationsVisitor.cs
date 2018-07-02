using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree.Visitor
{
    /// <summary>
    /// ExpressionVisitor use recursion to visit a expression
    /// Visit is an entrance
    /// Check the type of the expression first, then call relevant private visit method. Do this process recursively.    /// 
    /// </summary>
    public class OperationsVisitor :ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return base.Visit(expression);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return base.VisitParameter(node);
        }

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            return base.VisitMethodCall(node);
        }

        /// <summary>
        /// Binary expression parsing
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression b)
        {
            if (b.NodeType == ExpressionType.Add)
            {
                Expression left = base.Visit(b.Left);
                Expression right = base.Visit(b.Right);
                return Expression.Subtract(left, right);
            }

            return base.VisitBinary(b);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            return base.VisitConstant(node);
        }
    }
}

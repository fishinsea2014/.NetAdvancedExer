﻿using System.Linq.Expressions;

namespace ExpressionTree.Extend
{
    /// <summary>
    /// Create a new expression
    /// </summary>
    internal class NewExpressionVisitor :ExpressionVisitor
    {
        public ParameterExpression _NewParameter { get; private set; }
        public NewExpressionVisitor(ParameterExpression param)
        {
            this._NewParameter = param;
        }
        public Expression Replace(Expression exp)
        {
            return this.Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this._NewParameter;
        }
    }
}
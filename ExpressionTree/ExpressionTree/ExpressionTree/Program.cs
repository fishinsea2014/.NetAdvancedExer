using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    /// <summary>
    /// Action<> is a generic delegate with 0 to 16 arguments and no return value
    /// Func<> is a generic delegate with 0 to 16 arguments and with return value as well.
    /// Expression tree is a syntax tree, or a data structure. It can be interpreted.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //#region Action<> and Func<>
            //{ Action<int> a1 = i => Console.WriteLine(i);
            //    Action a2 = () => Console.WriteLine("I am an empty action");
            //    a1.Invoke(5);

            //    Func<int> f1 = () => 1;
            //    Func<string, string> f2 = (s) => s + " end";

            //    Console.WriteLine(f2.Invoke("Jason"));
            //}
            //#endregion
            //{
            //    #region Expression
            //    Expression<Func<int, int, int>> exp1 = (m, n) => m * n + 2; //Lambda initiate an expression
            //                                                                //ParameterExpression
            //    ExpressionVisitorTest.Show();

            //    #endregion
            //}

            {
                #region Modify Expression
                ExpressionVisitorTest.Show();
                #endregion
            }
            Console.Read();

        }
    }
}

using ExpressionTree.MappingExtend;
using ExpressionTree.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{/// <summary>
/// Expresion visitor
/// </summary>
    class ExpressionVisitorTest
    {
        private static int Get(int k)
        {
            return 5;
        }
        public static void Show()
        {
            {
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2 + 3 + Get(m);
                // Change the expression exp to m*n -2
                OperationsVisitor visitor = new OperationsVisitor();
                Expression expNew = visitor.Modify(exp);
            }

            {
                ///Parse a lambda to a sql script, parse where condition
                ///ORM maps the database to program memory and manages the database by manipulating objects
                ///Developers don't need to know details of database.
                var source = new List<People>().AsQueryable();
                var result = source.Where<People>(p => p.Age > 5)
                    .Where(p => p.Name.Equals("124"))
                    .Where(p => p.Age < 10);
                    //.ToList() //Only here execute the sql  
                Expression<Func<People, bool>> lambda = x => x.Age > 5;
                ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
                visitor.Visit(lambda);
                Console.WriteLine(visitor.Condition());
            }

            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Id > 5
                                                             && x.Name.StartsWith("1")
                                                             && x.Name.EndsWith("1")
                                                             && x.Name.Contains("1");
                string sql  = string.Format("Delete From [{0}] WHERE {1}", typeof(People).Name, "[Age]>5 AND [ID]>5");
                ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
                visitor.Visit(lambda);
                var result = visitor.Condition();
                Console.WriteLine(result);

                // Queryable is to parse linq to sql script
            }

            {
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5 || (x.Name == "A" && x.Id > 5);
                Expression<Func<People, bool>> lambda2 = x => (x.Age > 5 || x.Name == "A") && x.Id > 5;

                ConditionBuilderVisitor vistor = new ConditionBuilderVisitor();
                vistor.Visit(lambda);
                Console.WriteLine(vistor.Condition());
                vistor.Visit(lambda1);
                Console.WriteLine(vistor.Condition());
                vistor.Visit(lambda2);
                Console.WriteLine(vistor.Condition());
            }

            {
                //Link expression
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;

            }

        }
    }
}

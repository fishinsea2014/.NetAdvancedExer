using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("***************Lambda*****************");
                LambdaShow lambdaShow = new LambdaShow();
                lambdaShow.Show();
            }
            {
                object o1 = new 
                {
                    Id = 3,
                    age = 25
                };
                // o1.Id  //not work

                dynamic o2 = new
                {
                    Id = 3,
                    age = 25
                };

                Console.WriteLine(o2.Id); //dynamic could ignore the compiler checking.

                var o3 = new
                {
                    Id = 3,
                    age = 25
                };

                Console.WriteLine(o3.Id); //dynamic could ignore the compiler checking.
            }
            #region ExtendMethod
            {
                Student student = new Student()
                {
                    Id = 1,
                    Name = "Jason",
                    Age = 25,
                    ClassId = 2
                };

                string s = null;
                student.Study();
                student.StudyHard();
                //又要增加方法  又不想(不能)修改
                student.Sing();
                ExtendMethod.Sing(student);

                int? iValue = null;
                int r1=iValue.ToInt(0);

                int i1 = 2, i2 = 4;
                bool r2=i1.greaterThan(i2);

                int r3=student.Length();
            }
            #endregion

            #region linq
            {
                Console.WriteLine("***************Linq*****************");
                LinqShow show = new LinqShow();
                show.Show();
            }
            #endregion


            Console.Read();
        }
    }
}

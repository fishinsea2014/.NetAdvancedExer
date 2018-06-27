using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    public delegate void NoReturnNoParaOutClass(); //Delegate could set outside of a class.

    public class MyDelegate
    {
        /// <summary>
        /// Encapsulate a method as an argument.
        /// Delegate take method as arguments.
        /// Asynchronous multithreading
        /// The multicast delegate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        //Declare a delegate
        public delegate void NoReturnNoPara<T>(T t);
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            Student student = new Student()
            {
                Id = 123,
                Name = "JASON",
                Age = 32,
                ClassId = 1
            };
            student.Study();
            {
                //NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
                //method.Invoke(); //Execute DoNothing method.
                //method(); // Same as method.Invoke()

            }

            //Multicast delegate: a variable holds multiple methods, which can add or subtract.
            //The invoke can be executed sequentially
            //+= adds methods to the delegate instance in order to form the method chain, and when Invoke, it executes in order
            //Milticast delegate could not be async.
            Student studentNew = new Student();

            Console.WriteLine("+=");
            NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);//No () for argument method
            method += new NoReturnNoPara(DoNothingStatic);
            method += new NoReturnNoPara(studentNew.Study);
            method += new NoReturnNoPara(Student.StudyAdvanced);
            method += new NoReturnNoPara(this.DoNothing);

            method.Invoke();

            Console.WriteLine("-=");
            //-= removes a method for the delegate instance, matches it from the end of the method chain
            //, and when the first one is fully matched, removes and removes only one, no and no exceptions
            method -= new NoReturnNoPara(DoNothing);
            method -= new NoReturnNoPara(studentNew.Study);

            //Go throught a methods list
            foreach (NoReturnNoPara item in method.GetInvocationList())
            {
                item.Invoke();
            }

            method.Invoke();

        }



        private int GetSomething()
        {
            return 1;
        }
        private int GetSomething2()
        {
            return 2;
        }

        private int GetSomething3()
        {
            return 3;
        }
        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
        }
        private static void DoNothingStatic()
        {
            Console.WriteLine("This is DoNothingStatic");
        }
    }
}

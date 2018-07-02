using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public delegate void NoReturnNoParaOutClass();
    public delegate void GenericDelegate<T>();
    public class LambdaShow
    {
        public delegate void NoReturnNoPara();
        public delegate void NoReturnWithPara(int x, int y);
        public delegate int WithReturnNoPara();
        public delegate string WithReturnWithPara(out int x, ref int y);

        public void Show()
        {
            int k = 1;
            {
                NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
            }

            {
                //anonymous methods
                NoReturnNoPara method = new NoReturnNoPara(delegate ()
                {
                    Console.WriteLine("this is do nothing in anonymous methods");
                });
            }

            {
                //Lambda expression
                NoReturnNoPara method = new NoReturnNoPara( () =>   //"=>" is called goes to.
                {
                    Console.WriteLine("this is do nothing in anonymous methods");
                });
                
            }
            {
                // Lambda expression is not a delegation, or an instance of a delegation. It's a class in another class, a internal method.
                NoReturnWithPara method = new NoReturnWithPara((int x, int y) => { });
                NoReturnWithPara method1 = new NoReturnWithPara((x,  y) => { }); // int could be ignored
                NoReturnWithPara method2 = (int x, int y) => { };  //left is decleration, right is a lambda expression


            }

        }
        private void DoNothing()
        {
            Console.WriteLine("This is DoNothing");
            
        }
    }


}

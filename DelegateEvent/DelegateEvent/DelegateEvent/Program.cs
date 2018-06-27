using DelegateEvent.DelegateExtend;
using DelegateEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    /// <summary>
    /// events: you can encapsulate a set of mutable actions/actions and assign them to a third party
    /// When the program is designed, we can divide the program into two parts: fix part and vairable part
    /// Fix part is predefined, can not be modified;
    /// Variable part can use event to implement an open interface, then the outside class can use them to extend the actions
    /// Framework: complete the fixed/generic parts, leaving the variable parts with extension points to support customization
    /// </summary>
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("=====Delegate and Event==========");
            try
            {
                {
                    //MyDelegate myDelegate = new MyDelegate();
                    //myDelegate.Show();
                }

                {
                    //ListExtend test = new ListExtend();
                    //test.Show();
                }

                {
                    //Use multicast delegate
                    Console.WriteLine("====Multicast delegate cat example====");
                    Cat cat = new Cat();
                    //Initiate the miao delegate
                    cat.MiaoDelegateHandler += new MiaoDelegate(new Mouse().Run);
                    cat.MiaoDelegateHandler += new MiaoDelegate(new Baby().Cry);
                    cat.MiaoDelegateHandler += new MiaoDelegate(new Mother().Wispher);
                    //cat.MiaoDelegateHandler.Invoke(); //Can be invoke outside the cat class, which is the different between the Event.
                    cat.MiaoNew();
                                    }

                {
                    //Use Event
                    Console.WriteLine("====Event cat miao example====");
                    Cat cat = new Cat();
                    //Initiate the miao delegate event
                    cat.MiaoDelegateHandlerEvent += new MiaoDelegate(new Mouse().Run);
                    cat.MiaoDelegateHandlerEvent += new MiaoDelegate(new Baby().Cry);
                    cat.MiaoDelegateHandlerEvent += new MiaoDelegate(new Mother().Wispher);
                    //cat.MiaoDelegateHandlerEvent.Invoke(); //Can not invoke outside the cat class, even in child class.
                    cat.MiaoEvent();

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.Read();

        }
    }
}

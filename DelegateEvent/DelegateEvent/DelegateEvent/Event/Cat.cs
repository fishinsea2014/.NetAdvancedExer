using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent.Event
{
    public class Cat
    {
        public void Miao()
        {
            Console.WriteLine("{0} Miao", this.GetType().Name);

            new Mouse().Run();
            new Baby().Cry();
            new Mother().Wispher();
            //new Brother().Turn();
            //new Father().Roar();
            //new Neighbor().Awake();
            //new Stealer().Hide();
            //new Dog().Wang();
        }

        public MiaoDelegate MiaoDelegateHandler;
        public void MiaoNew()
        {
            Console.WriteLine($"{this.GetType().Name} MiaoNew");
            if (this.MiaoDelegateHandler !=null)
            {
                this.MiaoDelegateHandler.Invoke();
            }
        }

        //Miao event
        // event: is an instance of a delegate with an event keyword that limits the ability of a variable to be externally invoked/assigned a value directly
        // what are the differences and connections between delegation and events?
        // delegation is a type, such as Student
        // event is an instance of the delegate type, such as baby cry.
        public event MiaoDelegate MiaoDelegateHandlerEvent;
        public void MiaoEvent()
        {
            Console.WriteLine($"{this.GetType().Name} MiaoNew");
            if (this.MiaoDelegateHandlerEvent != null)
            {
                this.MiaoDelegateHandlerEvent.Invoke();
            }
        }

        //Cat miao, then triger a series of event


        //    public MiaoDelegate MiaoDelegateHandler;
        //    public void MiaoNew()
        //    {
        //        Console.WriteLine("{0} MiaoNew", this.GetType().Name);
        //        if (this.MiaoDelegateHandler != null)
        //        {
        //            this.MiaoDelegateHandler.Invoke();
        //        }
        //    }

        // event: is an instance of a delegate with an event keyword that limits the ability of a variable to be externally invoked/assigned a value directly
        // what are the differences and connections between delegation and events?
        // delegation is a type, such as Student
        // event is an instance of the delegate type, such as baby cry.
        //    public event MiaoDelegate MiaoDelegateHandlerEvent;
        //    public void MiaoNewEvent()
        //    {
        //        Console.WriteLine("{0} MiaoNewEvent", this.GetType().Name);
        //        if (this.MiaoDelegateHandlerEvent != null)
        //        {
        //            this.MiaoDelegateHandlerEvent.Invoke();
        //        }
        //    }

        //    //观察者模式

        //}

        //public class ChildClass : Cat
        //{
        //    public void Show()
        //    {
        //        this.MiaoDelegateHandlerEvent += null;
        //        //if (this.MiaoDelegateHandlerEvent != null)
        //        //{
        //        //    this.MiaoDelegateHandlerEvent.Invoke();
        //        //}
        //    }

        //}

        //public delegate void MiaoDelegate();
    }

    public delegate void MiaoDelegate();
}

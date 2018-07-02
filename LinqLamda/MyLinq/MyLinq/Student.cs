using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("{0} {1} is learning .Net", this.Id, this.Name);
        }

        public void StudyHard()
        {
            Console.WriteLine("{0} {1} working hard on learning .net", this.Id, this.Name);
        }

        //public void Sing()
        //{
        //    Console.WriteLine("Sing a Song");
        //}
    }

    /// <summary>
    /// 
    /// </summary>
    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}

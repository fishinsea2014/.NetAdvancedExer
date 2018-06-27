using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("Learning the .net course");
        }

        public static void StudyAdvanced()
        {
            Console.WriteLine("Learning the advanced .net course");
        }

        public static void Show()
        {
            Console.WriteLine("123");
        }
    }
}

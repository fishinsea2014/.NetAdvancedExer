using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    
    public static class ExtendMethod
    {
        /// <summary>
        /// Extension methods: static methods within a static class, with this before the first argument type
        /// purpose: you can add methods without modifying classes;
        ///It's just a little bit more convenient
        /// defect: preferred invocation of an instance method of type (with potential risks)
        /// extends base type, causing any subclass to have this method and possibly overridden something
        /// specify type extensions, not against base types otherwise the cost is too high
        /// there is no extension attribute
        /// </summary>
        


        public static void Sing(this Student stu)  //Add  a new method to the Student instance.
        {
            Console.WriteLine($"{stu.Name} sing a song.");
        }

        public static int ToInt(this int? iValue, int defaultValue = 0)
        {
            //The ?? operator is called the null-coalescing operator. 
            //It returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
            return iValue ?? defaultValue;
        }

        public static bool greaterThan(this int value1, int value2)
        {
            return value1 > value2;
        }

        public static int Length(this object oValue)
        {
            return oValue == null ? 0 : oValue.ToString().Length;
        }

        //Filter student list
        public static List<Student> StuWhere (this List<Student> source, Func<Student,bool> func)
        {
            var list = new List<Student>();
            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }

        //Refactor the StuWhere to a GenericWhere, which could deal with other classese.
        public static List<T> GenericWhere<T>(this List<T> source, Func<T, bool> func)
        {
            var list = new List<T>();
            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }


        //Introduce enumerable, get the data when necessary. Call this method only when use the result.
        public static IEnumerable<T> EnumWhere<T>(this List<T> source, Func<T, bool> func)
        {
            if (source == null)
            {
                throw new Exception("Source is null");
            }

            if (func == null)
            {
                throw new Exception("func is null");
            }

            foreach (var item in source)
            {
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEvent.DelegateExtend
{
# region DefineData

    /// <summary>
    /// Data for exercise
    /// </summary>
    class ListExtend
    {
        private List<Student> GetStudentList()
        {
            #region Initiate data
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="Jason",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="hao",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="Water",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="Hellen",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="Mike",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="Lee",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="Jack",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="yoyo",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="Emy",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="Faye",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Arden",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Emily",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Fish",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="May",
                    ClassId=2,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="yoyo",
                    ClassId=3,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="unknown",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion
            return studentList;
        }
        #endregion

        public delegate bool SelectDelegate(Student student);

        //Select conditions
        private bool AgeCondition(Student student)
        {
            return student.Age > 25;
        }

        private bool LengthThan(Student student)
        {
            return student.Name.Length > 2;
        }
        private bool AllThan(Student student)
        {
            return student.Name.Length > 2 && student.Age > 25 && student.ClassId == 2;
        }

        public void Show()
        {
            List<Student> studentList = this.GetStudentList();
            {
                SelectDelegate selectDelegate = new SelectDelegate(this.AgeCondition);
                List<Student> result = this.GetListDelegate(studentList, selectDelegate);
                Console.WriteLine($"{result.Count()} students is found by age.");
            }

            {
                SelectDelegate selectDelegate = new SelectDelegate(this.LengthThan);
                List<Student> result = this.GetListDelegate(studentList, selectDelegate);
                Console.WriteLine($"{result.Count()} students is found by length of name.");
            }

            {
                SelectDelegate selectDelegate = new SelectDelegate(this.AllThan);
                List<Student> result = this.GetListDelegate(studentList, selectDelegate);
                Console.WriteLine($"{result.Count()} students is found by both length of name and age.");
            }


        }

        ///Use delegate implement select student
        ///Share basic select logic
        ///Use delegate to decouple and reduces duplication of code.
        private List<Student> GetListDelegate(List<Student> source, SelectDelegate method)
        {
            List<Student> result = new List<Student>();
            foreach (Student student in source)
            {
                if (method.Invoke(student))
                {
                    result.Add(student);
                }
            }
            return result;
        }




    }
}

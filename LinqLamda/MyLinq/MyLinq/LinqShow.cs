using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
    /// <summary>
    /// This is linq to enumerable object
    /// On top of that, there are:linq to sql, linq to xml, linq to Excel/Nosql or even linq to everything. 
    /// 
    /// </summary>
    class LinqShow
    {
        #region DataInit
        private List<Student> GetStudentList()
        {
            List<Student> studentList = new List<Student>();
            for (int i = 0; i < 25; i++)
            {
                Student s = new Student()
                {
                    Id = i,
                    Name = $"name{i.ToString()}",
                    ClassId = i % 7,
                    Age = 40 % (i+1)
                };

                studentList.Add(s);
            }

            return studentList;
        }
        #endregion

        public void Show()
        {
            List<Student> studentList = this.GetStudentList();
            //Filter student list according to a consition
            var list = new List<Student>();
            var resultAge = studentList.StuWhere(s => s.Age < 10);
            var resultClass = studentList.StuWhere(s => s.ClassId == 3); //Decalrative programming instead of imperative programming
            var resultClassByGeneric = studentList.GenericWhere<Student>(s => s.ClassId == 3); //Abstract to a generic method
            var resultEnum = studentList.EnumWhere<Student>  (s => s.ClassId == 3);
            var resultIntList = new List<int> { 1, 3, 4, 5, 6, 7 }.GenericWhere(i => i > 3);
            var resultLinq = studentList.Where<Student>(s => s.ClassId == 3).Select<Student,int>(s => s.Age); //Selece project the Student to its name length.
                                                                                                              //This return the age of student, which classId is 3.

            var listLinq1 = from s in studentList
                            where s.ClassId == 3
                            select s.Name;


            var listLinqNewObj = studentList.Where(s => s.Age < 10)   //Choose students whoes age less than 10. Then return a new object.
                                            .Select(s => new
                                            {
                                                IdName = s.Id +s.Name,
                                                ClassName = s.ClassId ==2 ? "Advanced class" : "Others"
                                            });

            var listLinqNewObjOrdered = studentList.Where(s => s.Age < 10)   //Choose students whoes age less than 10. Then return a new object.
                                            .Select(s => new
                                            {
                                                ID = s.Id,
                                                ClassID = s.ClassId,
                                                IdName = s.Id + s.Name,
                                                ClassName = s.ClassId == 2 ? "Advanced class" : "Others"
                                            })
                                            .OrderBy(s => s.ClassID)  // Order
                                            .OrderByDescending(s => s.ID) //Decending order
                                            .Skip(2) // Jump 2 items
                                            .Take(5); //Return 5 items.

            var listLinqNewObjGrouped = studentList.Where(s => s.Age < 10)   //Group by.
                                            .GroupBy(s => s.ClassId)
                                            .Select(s => new
                                            {
                                                key = s.Key,
                                                maxAge = s.Max(t =>t.Age)
                                            })
                                            ;



            foreach (var item in resultEnum)
            {
                Console.WriteLine(item.Name);
            }
        }


    }
}
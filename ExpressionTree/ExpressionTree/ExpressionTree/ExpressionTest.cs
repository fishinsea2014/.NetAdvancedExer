using ExpressionTree.MappingExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    class ExpressionTest
    {
        public static void Show()
        {
            {
                //Hard copy people to peopleCopy
                People people = new People()
                {
                    Id = 11,
                    Name = "Eleven",
                    Age = 31
                };
                PeopleCopy peopleCopy = new PeopleCopy()
                {
                    Id = people.Id,
                    Name = people.Name,
                    Age = people.Age
                };

                //By reflection, fit different type of classes.
                var resultReflection = ReflectionMapper.Trans<People, PeopleCopy>(people);

                //By serialization
                var resultSerialization = SerializaMapper.Trans<People, PeopleCopy>(people);

                //By expression, 1. generic, 2. high performance. Could hard program dynamically and cache the result.
                var resultExpression =  ExpressionGenericMapper<People,PeopleCopy>.Trans(people);
                var resultExpression1 = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);




            }
        }
    }
}

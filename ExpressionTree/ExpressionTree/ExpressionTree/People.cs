using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTree
{
    /// <summary>
    /// People
    /// </summary>
    class People
    {

        public int Age { get; set; }
        public string Name { get; set; }

        public int Id;
    }

    /// <summary>
    /// People Target
    /// </summary>
    public class PeopleCopy
    {
        public int Age { get; set; }
        public string Name { get; set; }//ShortName

        public int Id;
    }
}

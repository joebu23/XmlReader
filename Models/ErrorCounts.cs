using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlReader.Models
{
    public class ErrorCounts
    {
        public List<Project> Projects { get; set; }
 
        public class Project
        {
            public string Name { get; set; }
            public int ErrorCount { get; set; }
        }
    }
}

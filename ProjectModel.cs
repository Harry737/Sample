using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ProjectModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Action
        {
            public string _class { get; set; }
        }

        public class Build
        {
            public string _class { get; set; }
            public List<Action> actions { get; set; }
            public int number { get; set; }
        }

        public class Job
        {
            public string _class { get; set; }
            public string name { get; set; }
            public List<Build> builds { get; set; }
        }

        public class Root1
        {
            public string _class { get; set; }
            public List<Job> jobs { get; set; }
        }

        public class Project
        {
            public string ProjectName { get; set; }
            public string BranchName { get; set; }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sample
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Caus
        {
            public string _class { get; set; }
            public string shortDescription { get; set; }
        }

        public class Branch
        {
            public string SHA1 { get; set; }
            public string name { get; set; }
        }

        public class Marked
        {
            public string SHA1 { get; set; }
            public List<Branch> branch { get; set; }
        }

        public class Revision
        {
            public string SHA1 { get; set; }
            public List<Branch> branch { get; set; }
        }

        public class Build
        {
            public int buildNumber { get; set; }
            public object buildResult { get; set; }
            public Marked marked { get; set; }
            public Revision revision { get; set; }
        }

        public class Action
        {
            public string _class { get; set; }
            public List<Caus> causes { get; set; }
            public int? blockedDurationMillis { get; set; }
            public int? blockedTimeMillis { get; set; }
            public int? buildableDurationMillis { get; set; }
            public int? buildableTimeMillis { get; set; }
            public int? buildingDurationMillis { get; set; }
            public int? executingTimeMillis { get; set; }
            
            public int? subTaskCount { get; set; }
            public int? waitingDurationMillis { get; set; }
            public int? waitingTimeMillis { get; set; }
            public Build build { get; set; }
            public List<string> remoteUrls { get; set; }
            public string scmName { get; set; }
        }

        public class Author
        {
            public string absoluteUrl { get; set; }
            public string fullName { get; set; }
        }

        public class Path
        {
            public string editType { get; set; }
            public string file { get; set; }
        }

        public class Item
        {
            public string _class { get; set; }
            public List<string> affectedPaths { get; set; }
            public string commitId { get; set; }
            public object timestamp { get; set; }
            public Author author { get; set; }
            public string authorEmail { get; set; }
            public string comment { get; set; }
            public string date { get; set; }
            public string id { get; set; }
            public string msg { get; set; }
            public List<Path> paths { get; set; }
        }

        public class ChangeSet
        {
            public string _class { get; set; }
            public List<Item> items { get; set; }
            public string kind { get; set; }
        }

        public class Culprit
        {
            public string absoluteUrl { get; set; }
            public string fullName { get; set; }
        }

        public class Root
        {
            public string _class { get; set; }
            public List<Action> actions { get; set; }
            public List<object> artifacts { get; set; }
            public bool building { get; set; }
            public object description { get; set; }
            public string displayName { get; set; }
            public int duration { get; set; }
            public int estimatedDuration { get; set; }
            public object executor { get; set; }
            public string fullDisplayName { get; set; }
            public string id { get; set; }
            public bool keepLog { get; set; }
            public int number { get; set; }
            public int queueId { get; set; }
            public string result { get; set; }
            public long timestamp { get; set; }
            public string url { get; set; }
            public string builtOn { get; set; }
            public ChangeSet changeSet { get; set; }
            public List<Culprit> culprits { get; set; }
        }




    }
}

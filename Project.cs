using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIRA_Bug_List_Creator
{
    public class Project
    {
        private string strProjectName;
        private List<JIRAIssue> JIRAIssues;

        public string ProjectName
        {
            get
            {
                return this.strProjectName;
            }
            set
            {
                this.strProjectName = value;
            }
        }

        public List<JIRAIssue> Issues
        {
            get
            {
                return this.JIRAIssues;
            }
            set
            {
                this.JIRAIssues = value;
            }
        }

        public Project(string project)
        {
            this.strProjectName = project;
            this.JIRAIssues = new List<JIRAIssue>();
        }
    }
}

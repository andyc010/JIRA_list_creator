using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace JIRA_Bug_List_Creator
{
    public class JIRAIssue
    {        
        private string strLinkURL;  // the actual URL of the JIRA issue - e.g. https://.../browse/QA-1234
        //private string strProject;  // the project for the JIRA issue - e.g. Smoothie Blast
        private string strKey;  // the key or identifier for the JIRA issue - e.g. QA-1234
        private string strSummary;  // the summary or title of the JIRA issue - e.g. "The game does not start after inserting money."
        private string strPriority; // the priority of an issue - e.g. Major

        public string Link
        {
            get
            {
                return this.strLinkURL;
            }
            set
            {
                this.strLinkURL = value;
            }
        }

        /*
        public string Project
        {
            get
            {
                return this.strProject;
            }
            set
            {
                this.strProject = value;
            }
        }
        */

        public string Key
        {
            get
            {
                return this.strKey;
            }
            set
            {
                this.strKey = value;
            }
        }

        public string Summary
        {
            get
            {
                return this.strSummary;
            }
            set
            {
                this.strSummary = value;
            }
        }

        public string Priority
        {
            get
            {
                return this.strPriority;
            }
            set
            {
                this.strPriority = value;
            }
        }

        /*public JIRAIssue(string link, string project, string key, string summary, string priority)
        {
            this.strLinkURL = link;
            this.strKey = key;
            //this.strProject = project;
            this.strSummary = summary;
            this.strPriority = priority;
        }*/

        public JIRAIssue(string link, string key, string summary, string priority)
        {
            this.strLinkURL = link;
            this.strKey = key;
            this.strSummary = summary;
            this.strPriority = priority;
        }
    }
}

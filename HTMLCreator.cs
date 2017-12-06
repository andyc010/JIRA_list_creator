using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace JIRA_Bug_List_Creator
{
    class HTMLCreator
    {
        // string to hold the HTML
        private string strHTML = "";

        // string to determine first project
        private Boolean isFirstProject = true;

        // OLD: string to hold the current project
        //private string currentProject = "";        

        public string HTMLString
        {
            get
            {
                return this.strHTML;
            }
            set
            {
                this.strHTML = value;
            }
        }

        // OLD CODE
        //public string Project
        //{
        //    get
        //    {
        //        return this.currentProject;
        //    }
        //    set
        //    {
        //        this.currentProject = value;
        //    }
        //}

        // OLD: constructor
        //public HTMLCreator()
        //{
        //    this.strHTML = "";
        //    this.currentProject = "";
        //}

        // OLD CODE
        //public string constructHTMLString(List<JIRAIssue> issues)
        //{            
        //    /*
        //     * Pseudocode for algorithm on what exactly to print out
        //     * 
        //     * 1) Check project
        //     * 2) If project is new, print out the project title
        //     * 3) Print out the issue
        //     * 4) Go to the next issue & back to Step 1
        //     * 
        //     */

        //    foreach (JIRAIssue issue in issues)
        //    {
        //        // check for a new project... (should be valid even for the first issue)
        //        if (issue.Project != this.currentProject)
        //        {
        //            if (isFirstProject == true)
        //            {
        //                // set it to false
        //                isFirstProject = false;
        //            }
        //            else
        //            {
        //                this.strHTML += "<br/><br/>";
        //            }

        //            // set _currentProject with the current issue's project value
        //            this.currentProject = issue.Project;

        //            // create the title
        //            this.strHTML += constructProjectTitle(this.currentProject);
        //        }

        //        // create issue
        //        this.strHTML += constructIssue(issue.Link, issue.Key, issue.Summary, issue.Priority);
        //    }

        //    return this.strHTML;
        //}

        public string constructHTMLString(List<Project> projects)
        {
            /*
             * Pseudocode on what to print out
             * 1) For each project...
             * 1a) ...print the project in a title
             * 1b) ...start the ordered list (<ol>)
             * 1c) ...print all the JIRA issues for the project
             * 1d) ...stop the ordered list (</ol>)
             * 
             */

            foreach (Project singleProject in projects)
            {
                // need page breaks between projects except the first one
                if (isFirstProject == true)
                {
                    // set variable to false
                    isFirstProject = false;
                }
                else
                {
                    this.strHTML += "<br/><br/>";
                }

                this.strHTML += constructProjectTitle(singleProject.ProjectName) + "<ol>";

                foreach (JIRAIssue singleIssue in singleProject.Issues)
                {
                    this.strHTML += constructIssue(singleIssue.Link, singleIssue.Key, singleIssue.Summary, singleIssue.Priority);
                }

                // put the closing ordered list tag at the end
                this.strHTML += "</ol>";
            }

            return this.strHTML;
        }

        public string constructProjectTitle(string project)
        {
            // add the project title

            string prj = "";

            prj = "<b><u>" + project + "</u></b><br/><br/>";

            return prj;
        }

        public string constructIssue(string link, string key, string summary, string priority)
        {
            // add the issue

            string issue = "";

            issue = "<li><b><a href=\"" + link + "\">" + key + "</a>" + " - (" + priority + ") " + summary + "</b></li><br/>"; 

            return issue;
        }
    }
}

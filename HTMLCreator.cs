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
        private string _strHTML = "";

        // string to hold the current project
        private string _currentProject = "";

        // string to determine first project
        private Boolean isFirstProject = true;

        public string HTMLString
        {
            get
            {
                return _strHTML;
            }
            set
            {
                _strHTML = value;
            }
        }

        public string currentProject
        {
            get
            {
                return _currentProject;
            }
            set
            {
                _currentProject = value;
            }
        }

        // constructor
        public HTMLCreator()
        {
            _strHTML = "";
            _currentProject = "";
        }

        public string constructHTMLString(List<JIRAIssue> issues)
        {            
            /*
             * Pseudocode for algorithm on what exactly to print out
             * 
             * 1) Check project
             * 2) If project is new, print out the project title
             * 3) Print out the issue
             * 4) Go to the next issue & back to Step 1
             * 
             */

            foreach (JIRAIssue issue in issues)
            {
                // check for a new project... (should be valid even for the first issue)
                if (issue.Project != _currentProject)
                {
                    if (isFirstProject == true)
                    {
                        // set it to false
                        isFirstProject = false;
                    }
                    else
                    {
                        _strHTML += "<br/><br/>";
                    }
                    
                    // set _currentProject with the current issue's project value
                    _currentProject = issue.Project;

                    // create the title
                    _strHTML += constructProjectTitle(_currentProject);
                }

                // create issue
                _strHTML += constructIssue(issue.Link, issue.Key, issue.Summary, issue.Priority);
            }

            return _strHTML;
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

            issue = "<li><b><a href=\"" + link + "\">" + key + "</a>" + " - (" + priority + ") " + summary + "</b><br/>"; 

            return issue;
        }
    }
}

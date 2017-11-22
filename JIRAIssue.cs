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
        private string strProject;  // the project for the JIRA issue - e.g. Smoothie Blast
        private string strKey;  // the key or identifier for the JIRA issue - e.g. QA-1234
        private string strSummary;  // the summary or title of the JIRA issue - e.g. "The game does not start after inserting money."
        private string strPriority; // the priority of an issue - e.g. Major

        public string Link
        {
            get
            {
                return strLinkURL;
            }
            set
            {
                strLinkURL = value;
            }
        }

        public string Project
        {
            get
            {
                return strProject;
            }
            set
            {
                strProject = value;
            }
        }

        public string Key
        {
            get
            {
                return strKey;
            }
            set
            {
                strKey = value;
            }
        }

        public string Summary
        {
            get
            {
                return strSummary;
            }
            set
            {
                strSummary = value;
            }
        }

        public string Priority
        {
            get
            {
                return strPriority;
            }
            set
            {
                strPriority = value;
            }
        }

        
        public JIRAIssue(string link, string project, string key, string summary, string priority)
        {
            strLinkURL = link;
            strKey = key;
            strProject = project;
            strSummary = summary;
            strPriority = priority;
        }

        /*
        // custom collection class - is this necessary?
        public class JIRA_Issues : IEnumerable
        {
            private JIRAIssue[] _JIRA_Issues;

            public JIRA_Issues(JIRAIssue[] jiraIssueArray)
            {
                _JIRA_Issues = new JIRAIssue[jiraIssueArray.Length];

                for (int i = 0; i < jiraIssueArray.Length; i++)
                {
                    _JIRA_Issues[i] = jiraIssueArray[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return (IEnumerator)GetEnumerator();
            }

            public jiraIssuesEnum GetEnumerator()
            {
                return new jiraIssuesEnum(_JIRA_Issues);
            }
        }

        public class jiraIssuesEnum : IEnumerator
        {
            public JIRAIssue[] _jiraIssues;

            int position = -1;

            public jiraIssuesEnum(JIRAIssue[] list)
            {
                _jiraIssues = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _jiraIssues.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public JIRAIssue Current
            {
                get
                {
                    try
                    {
                        return _jiraIssues[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
            */
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;


namespace JIRA_Bug_List_Creator
{
    class XML_manipulator
    {
        /* 
         * Prerequisites for using the class:
         * 1) The XML document must have an node "item"
         * EDIT: Not doing this, so changes need to be made in the code -> 2) Items are ordered by project, then by priority, then creation date
         * 
        */

        private XmlDocument xmlDoc = new XmlDocument();

        // setter function
        public XmlDocument xmld
        {
            get { return this.xmlDoc; }
            set { this.xmlDoc = value; }
        }

        // class constructor
        public XML_manipulator()
        {

        }

        // function that takes an XML document and converts it to a List of Projects
        //public List<Project> createProjects(string xmlFile)
        //{
        //    Boolean isCreated = true;

        //    List<Project> projects = new List<Project>();

        //    this.xmlDoc.Load(xmlFile);

        //    // used XPath to specify which xml nodes to look at
        //    XmlNodeList itemNodes = this.xmlDoc.SelectNodes("//rss/channel/item");

        //    foreach (XmlNode node in itemNodes)
        //    {
        //        // grab certain nodes
        //        XmlNode linkNode = node.SelectSingleNode("link");
        //        XmlNode projectNode = node.SelectSingleNode("project");
        //        XmlNode keyNode = node.SelectSingleNode("key");
        //        XmlNode summaryNode = node.SelectSingleNode("summary");
        //        XmlNode priorityNode = node.SelectSingleNode("priority");

        //        // see if an existing Project is made with the name of the projectNode
        //        if(projectNode.InnerText)
        //    }

        //    return projects;
        //}

        // function that takes an XML document and converts it to a List of JIRAIssues
        public List<JIRAIssue> createIntermediateDoc(string xmlFile)
        {
            List<JIRAIssue> JIRAIssues = new List<JIRAIssue>();

            this.xmlDoc.Load(xmlFile);

            // used XPath to specify which xml nodes to look at
            XmlNodeList itemNodes = this.xmlDoc.SelectNodes("//rss/channel/item");

            foreach (XmlNode node in itemNodes)
            {
                // grab certain ones
                XmlNode linkNode = node.SelectSingleNode("link");
                XmlNode projectNode = node.SelectSingleNode("project");
                XmlNode keyNode = node.SelectSingleNode("key");
                XmlNode summaryNode = node.SelectSingleNode("summary");
                XmlNode priorityNode = node.SelectSingleNode("priority");

                if ((linkNode != null) && (projectNode != null) && (keyNode != null) && (summaryNode != null) & (priorityNode != null))
                {
                    JIRAIssues.Add(new JIRAIssue(linkNode.InnerText, keyNode.InnerText, summaryNode.InnerText, priorityNode.InnerText));
                }
            }

            return JIRAIssues;
        }

        // function that takes the XML document and gets a list of projects
        public List<Project> createProjectsList(string xmlFile)
        {
            List<Project> projects = new List<Project>();
            Boolean doesProjectExist = false;

            this.xmlDoc.Load(xmlFile);

            XmlNodeList itemNodes = this.xmlDoc.SelectNodes("//rss/channel/item");

            foreach (XmlNode node in itemNodes)
            {
                XmlNode linkNode = node.SelectSingleNode("link");
                XmlNode projectNode = node.SelectSingleNode("project");
                XmlNode keyNode = node.SelectSingleNode("key");
                XmlNode summaryNode = node.SelectSingleNode("summary");
                XmlNode priorityNode = node.SelectSingleNode("priority");

                if (projectNode != null)
                {
                    foreach (Project project in projects)
                    {
                        // check if the current node is in the list of projects
                        if (projectNode.InnerText == project.ProjectName)
                        {
                            doesProjectExist = true;

                            // add the JIRA issue into the current project
                            this.addJIRAIssuetoProject(project, linkNode.InnerText, keyNode.InnerText, summaryNode.InnerText, priorityNode.InnerText);
                            break;
                        }

                    }

                    if (doesProjectExist == false)
                    {
                        // add the project first...
                        this.addProject(projects, projectNode.InnerText);

                        // add the JIRA issue afterwards
                        this.addJIRAIssuetoProject(projects.Last(), linkNode.InnerText, keyNode.InnerText, summaryNode.InnerText, priorityNode.InnerText);
                    }
                }

                // set the doesProjectExist variable back to false, just in case
                doesProjectExist = false;
            }

            return projects;
        }

        private void addProject(List<Project> listOfProjects, string strProjectName)
        {
            listOfProjects.Add(new Project(strProjectName));
        }

        private void addJIRAIssuetoProject(Project project, string linkValue, string keyValue, string summaryValue, string priorityValue)
        {
            project.Issues.Add(new JIRAIssue(linkValue, keyValue, summaryValue, priorityValue));
        }
    }  
}

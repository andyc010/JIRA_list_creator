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
         * 2) Items are ordered by project, then by priority, then creation date
         * 
        */

        private XmlDocument _xmlDoc = new XmlDocument();    

        // setter function
        public XmlDocument xmld 
        {
            get { return _xmlDoc; }
            set { _xmlDoc = value; }        
        }

        // class constructor
        public XML_manipulator()
        {

        }

        // function that takes an XML document and converts it to a List of JIRAIssues
        public List<JIRAIssue> createIntermediateDoc(string xmlFile)
        {
            List<JIRAIssue> JIRAIssues = new List<JIRAIssue>();

            _xmlDoc.Load(xmlFile);

            XmlNodeList itemNodes = _xmlDoc.SelectNodes("//rss/channel/item");

            foreach (XmlNode node in itemNodes)
            {
                XmlNode linkNode = node.SelectSingleNode("link");
                XmlNode projectNode = node.SelectSingleNode("project");
                XmlNode keyNode = node.SelectSingleNode("key");
                XmlNode summaryNode = node.SelectSingleNode("summary");
                XmlNode priorityNode = node.SelectSingleNode("priority");

                if ((linkNode != null) && (projectNode != null) && (keyNode != null) && (summaryNode != null) & (priorityNode != null))
                {
                    JIRAIssues.Add(new JIRAIssue(linkNode.InnerText, projectNode.InnerText, keyNode.InnerText, summaryNode.InnerText, priorityNode.InnerText));

                }
                
            }

            return JIRAIssues;
        }
    }
}

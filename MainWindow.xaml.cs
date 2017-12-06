using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace JIRA_Bug_List_Creator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            List<JIRAIssue> issues;
            string finalHTMLstring;


            OpenFileDialog opnFileDialog = new OpenFileDialog();
            opnFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            opnFileDialog.InitialDirectory = Environment.CurrentDirectory;

            if (opnFileDialog.ShowDialog() == true)
            {
                XML_manipulator xmlManipulator = new XML_manipulator();
                HTMLCreator htmlCreator = new HTMLCreator();

                finalHTMLstring = htmlCreator.constructHTMLString(xmlManipulator.createProjectsList(opnFileDialog.FileName));

                lblFilename.Content = opnFileDialog.SafeFileName;
                wbCopyText.NavigateToString(finalHTMLstring);
            }
        }
    }
}

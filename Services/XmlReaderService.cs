using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using XmlReader.Models;

namespace XmlReader.Services
{
    public class XmlReaderService
    {
        private readonly XmlDocument _xmlDoc = new XmlDocument();

        public XmlReaderService(string fileName)
        {
            _xmlDoc.Load(fileName);
        }

        public ErrorCounts GetTotalStyleCopErrors()
        {
            var errors = new ErrorCounts();
            errors.Projects = new List<ErrorCounts.Project>();
            var homeNode = _xmlDoc.SelectNodes("/StyleCopReport/Solutions/Projects");
            foreach (XmlNode node in homeNode)
            {
                var errorCount = 0;
                var newProject = new ErrorCounts.Project();
                newProject.Name = node["Name"].InnerText;
                var sourceCodeFiles = node.SelectNodes("SourceCodeFiles");
                if (sourceCodeFiles != null)
                {
                    foreach (XmlNode innerNode in sourceCodeFiles)
                    {
                        errorCount = errorCount + (innerNode.ChildNodes.Count - 6);
                    }
                }

                newProject.ErrorCount = errorCount;
                errors.Projects.Add(newProject);
            }
            return errors;
        }


        public List<String> GetBoardsToSearch()
        {
            var returnStrings = new List<String>();
            if (_xmlDoc != null)
            {
                var boardNode = _xmlDoc.DocumentElement.SelectSingleNode("/Application/ServiceBoardsToSearch");
                if (boardNode != null)
                {
                    foreach (XmlNode node in boardNode)
                    {
                        returnStrings.Add(node.InnerText);
                    }
                }
            }
            return returnStrings;
        }

        public string GetHfoNumber()
        {
            try
            {
                return _xmlDoc.SelectSingleNode("/Application/FactoryOutletNumber").InnerText;
            }
            catch (NullReferenceException er)
            {
                return null;
            }
        }
       
    }
}

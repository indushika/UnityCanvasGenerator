using System;
using System.Collections.Generic;
using System.Xml;

namespace MF.Tools
{
    public class PenpotSVGReader : ISVGReader
    {
        public CanvasConfig ParseSVG(string svgContent)
        {
            var svgGroups = new List<Group>();

            XmlDocument document = new XmlDocument();
            document.LoadXml(svgContent);

            XmlNodeList groupNodes = document.GetElementsByTagName("g");
            foreach (XmlNode node in groupNodes)
            {
                var children = new List<IElement>();

                foreach (XmlNode child in node.ChildNodes)
                {
                    var element = new Component
                    {
                        Name = node.Name,
                        AttributeDataById = new Dictionary<string, string>()
                    };

                    foreach (XmlAttribute attr in child.Attributes)
                    {
                        element.AttributeDataById[attr.Name] = attr.Value;
                    }

                    children.Add(element);
                }

                var group = new Group
                {
                    Id = node.Attributes["id"]?.Value,
                    Name = node.Attributes["data-testid"]?.Value,
                    Children = children
                };

                svgGroups.Add(group);
            }

            return new CanvasConfig();
        }

        private void ProcessNode(XmlNode node)
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode is XmlElement)
                {
                    if(childNode.Name == "g")
                    {
                        var group = new Group
                        {
                            Id = childNode.Attributes["id"]?.Value,
                            Name = node.Attributes["data-testid"]?.Value,

                        };
                    }
                }
            }
        }
    }


}

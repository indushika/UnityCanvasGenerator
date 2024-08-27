using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

namespace MF.Tools
{
    public class PenpotSVGReader : ISVGReader
    {
        public CanvasConfig ParseSVG(string svgContent)
        {
            var svgGroups = new List<Group>();

            XmlDocument document = new XmlDocument();
            document.LoadXml(svgContent);

            XmlNode root = document.DocumentElement;
            var rootFilteredNode = (FilteredNode)ProcessNode(root);

            PrintNodes(rootFilteredNode, 0);

            return new CanvasConfig();
        }

        private FilteredNode? ProcessNode(XmlNode node)
        {
            if (node is XmlElement)
            {
                FilteredNode filteredNode = new FilteredNode
                {
                    Tag = node.Name,
                    Id = node.Attributes["id"]?.Value,
                    Name = node.Attributes["data-testid"]?.Value,
                    AttributeDataById = new Dictionary<string, string>(),
                    ChildNodes = new List<FilteredNode> ()
                };

                foreach (XmlAttribute attribute in node.Attributes)
                {
                    filteredNode.AttributeDataById.Add(attribute.Name, attribute.Value);
                }

                foreach (XmlNode childNode in node.ChildNodes)
                {
                    var processedChildNode = ProcessNode(childNode);

                    if (processedChildNode != null)
                        filteredNode.ChildNodes.Add((FilteredNode)processedChildNode);
                }

                //Debug.Log($"Tag: {filteredNode.Tag},  Name: {filteredNode.Id}");

                return filteredNode;
            }
            else
                return null;
        }

        private void PrintNodes(FilteredNode node, int depth)
        {
            string indent = new string(' ', depth * 4);
            Debug.Log($"{indent}Tag: {node.Tag}, Name: {node.Name}");

            foreach (var childNode in node.ChildNodes)
            {
                PrintNodes(childNode, depth + 1);
            }

        }
    }

    public struct FilteredNode
    {
        public string Id;
        public string Name;
        public string Tag;
        public Dictionary<string, string> AttributeDataById;

        public List<FilteredNode> ChildNodes;
    }


}

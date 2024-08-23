using System.Collections.Generic;

namespace MF.Tools
{
    public interface ISVGReader
    {
        CanvasConfig ParseSVG(string svgContent);
    }
    public struct Group : IElement
    {
        private string id;
        private string name;
        private Dictionary<string, string> attributesById;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<string, string> AttributeDataById { get => attributesById; set => attributesById = value; }

        public List<IElement> Children;
    }

    public struct Frame : IElement
    {
        private string id;
        private string name;
        private Dictionary<string, string> attributesById;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<string, string> AttributeDataById { get => attributesById; set => attributesById = value; }

        public List<Group> Groups;
    }

    public struct Component : IElement 
    {
        private string id;
        private string name;
        private Dictionary<string, string> attributesById;
        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public Dictionary<string, string> AttributeDataById { get => attributesById; set => attributesById = value; }
    }

    public interface IElement
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, string> AttributeDataById { get; set; }
    }
}

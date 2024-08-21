using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Tools
{
    public abstract class ElementData
    {
        private string name;
        private Rect rect;
        private List<ElementData> children;

        public string Name => name;
        public Rect Rect => rect;
        public List<ElementData> Children { get => children; set => children = value; } 

        public ElementData(string name, Rect rect)
        {
            this.name = name;
            this.rect = rect;
        }
    }


    public enum ElementType
    {
        Canvas,
        Panel,
        Text,
        Image,
        ScrollRect,
    }
}

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MF.Tools
{
    public abstract class ComponentData
    {
        private string name;
        private Rect rect;
        private List<ComponentData> children;

        public string Name => name;
        public Rect Rect => rect;
        public List<ComponentData> Children { get => children; set => children = value; } 

        public ComponentData(string name, Rect rect)
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

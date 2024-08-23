using System.Collections.Generic;
using UnityEngine;

namespace MF.Tools
{
    public class PenpotSVGProcessor : IRawDataProcessor
    {
        private ISVGReader svgReader;
        public PenpotSVGProcessor()
        {
            svgReader = new PenpotSVGReader();
        }
        public CanvasComponentData GetUIElementData(string rawData)
        {
            var canvasConfig = svgReader.ParseSVG(rawData);

            return new CanvasComponentData(string.Empty, new Rect());
        }
    }

}

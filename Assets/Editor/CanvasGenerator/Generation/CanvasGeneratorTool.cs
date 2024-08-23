namespace MF.Tools
{
    public class CanvasGeneratorTool
    {
        //Used by the Editor window script, passes the raw data (in the form of JSON, XML, HTML, etc) 
        //here we create different instances for all converter types

        private IRawDataProcessor dataProcessor;
        private string rawData;

        public CanvasGeneratorTool( FormatType type, string rawData)
        {
            this.rawData = rawData;

            if (type == FormatType.PenpotSVG)
            {
                dataProcessor = new PenpotSVGProcessor();
            }
            else if (type == FormatType.HTML)
            {

            }
        }

        public void GenerateCanvas()
        {
            ProcessRawData();
        }

        private void ProcessRawData()
        {
            dataProcessor.GetUIElementData(rawData);
        }
    }

    public enum FormatType
    {
        PenpotSVG = 0,
        HTML = 1,
    }
}

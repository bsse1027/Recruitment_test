using System.Xml.Serialization;

namespace DingConsoleAppSource.Models
{
    [XmlRoot(ElementName = "Header")]
    public class RequestMessageHeader
    {
        [XmlElement("Identifier")]
        public string? Identifier { get; set; }
        [XmlElement("MessageDate")]
        public string? MessageDate { get; set; }
        [XmlElement("MessageTime")]
        public string? MessageTime { get; set; }
    }
}

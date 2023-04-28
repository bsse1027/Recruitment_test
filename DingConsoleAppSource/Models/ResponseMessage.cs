using System.Xml.Serialization;

namespace DingConsoleAppSource.Models
{
    [XmlRoot("Message")]
    public class ResponseMessage
    {
        [XmlElement("Header")]
        public ResponseMessageHeader? Header { get; set; }
        [XmlElement("Body")]
        public ResponseMessageBody? Body { get; set;}
    }
}

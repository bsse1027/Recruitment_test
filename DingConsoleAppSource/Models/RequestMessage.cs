using System.Xml.Serialization;

namespace DingConsoleAppSource.Models
{
    [XmlRoot("ReqMessage")]
    public class RequestMessage
    {
        [XmlElement("Header")]
        public RequestMessageHeader? Header { get; set; }
        [XmlElement("Body")]
        public RequestMessageBody? Body { get; set;}

    }
}

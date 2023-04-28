using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DingConsoleAppSource.Models
{
    [XmlRoot(ElementName = "Header")]
    public class ResponseMessageHeader
    {
        [XmlElement("MessageDate")]
        public string? MessageDate { get; set; }
        [XmlElement("MessageTime")]
        public string? MessageTime { get; set; }
    }
}

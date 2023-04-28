using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DingConsoleAppSource.Models
{
    [XmlRoot(ElementName = "Body")]
    public class RequestMessageBody
    {
        [XmlElement("MessageID")]
        public int MessageID { get; set; }
        [XmlElement("PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [XmlElement("Amount")]
        public string? Amount { get; set; }
    }
}

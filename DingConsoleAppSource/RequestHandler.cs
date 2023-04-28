using DingConsoleAppSource.Models;
using System.Xml.Serialization;

namespace DingConsoleAppSource
{
    public class RequestHandler
    {
        static int currMessageID = 332526; //starting id is counted incrementally from the first sample request 
        public byte[]? BuildRequestMessage(string phoneNumber, string currAmount)
        {
            if (phoneNumber.Length > 12 || phoneNumber.Length < 0) return null;
            if (currAmount.Contains('.')) return null;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RequestMessage));
            RequestMessage message = new RequestMessage
            {
                Header = new RequestMessageHeader
                {
                    Identifier = "EZE",
                    MessageDate = DateTime.Now.ToString("ddMMyyyy"),
                    MessageTime = DateTime.Now.ToString("hhmmss")
                },
                Body = new RequestMessageBody
                {
                    MessageID = currMessageID++,
                    PhoneNumber = phoneNumber,
                    Amount = currAmount
                }
            };
            using (var stream = new MemoryStream())
            {
                xmlSerializer.Serialize(stream, message);
                return stream.ToArray();
            }
        }
    }
}

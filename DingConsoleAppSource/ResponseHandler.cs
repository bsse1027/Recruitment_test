using DingConsoleAppSource.Models;
using System.Text;
using System.Xml.Serialization;

namespace DingConsoleAppSource
{
    public class ResponseHandler
    {
        public ResponseMessage? ParseResponseToXML(byte[] response)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ResponseMessage));
            string? responseStr = DeserializeByteToXmlString(response);
            int endIndx = -1;
            for(int i=0; i<responseStr.Length; i++)
            {
                if (responseStr[i] == '<')
                {
                    endIndx = i;
                    break;
                }
            }
            responseStr = responseStr.Remove(0, endIndx); // as the sample responses have some leading strings before the first mark-up tag
            using (var reader = new StringReader(responseStr))
            {
                var output = xmlSerializer.Deserialize(reader) as ResponseMessage;
                return output;
            }  
        }

        public string DeserializeByteToXmlString(byte[] response)
        {
            return Encoding.Default.GetString(response);
        }

        public string parseResultCode(ResponseMessage? response)
        {
            if (response?.Body?.Result == "01") return "Success";
            else if (response?.Body?.Result == "99") return "Failure";
            else if (response?.Body?.Result == "999") return "Invalid Message";
            else return "Unknown result code";
        }
    }
}

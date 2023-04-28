using DingConsoleAppSource.Models;
using System.Text;

namespace DingConsoleApp.NunitTests
{
    public class ResponseHandlerTests
    {
        private ResponseHandler? _handler;
        [SetUp]
        public void Setup()
        {
            _handler = new ResponseHandler();
        }
        [Test]
        public void ParseResponseToXML_ReturnsValidResponseMessage()
        {
            //Arrange
            string responseXml = "EZE-XML-Msg02<Message>\r\n  " +
                "<Header>\r\n    " +
                "<MessageDate>20100324</MessageDate>\r\n    " +
                "<MessageTime>192806</MessageTime>\r\n  " +
                "</Header>\r\n  " +
                "<Body>\r\n    " +
                "<TransactionID>332527</TransactionID>\r\n    " +
                "<TransactionNumber>1210470</TransactionNumber>\r\n    " +
                "<PhoneNumber>639999999999</PhoneNumber>\r\n    " +
                "<Amount>0000002500</Amount>\r\n    " +
                "<Result>03</Result>\r\n  " +
                "</Body>\r\n</Message>";
            ResponseMessage? responseObject = new ResponseMessage
            {
                Header = new ResponseMessageHeader
                {
                    MessageDate = "20100324",
                    MessageTime = "192806"
                },
                Body = new ResponseMessageBody
                {
                    TransactionID = 332527,
                    TransactionNumber = 1210470,
                    PhoneNumber = "639999999999",
                    Amount = "0000002500",
                    Result = "03"
                }
            };
            byte[] responseByte = Encoding.Default.GetBytes(responseXml);
            //Act
            ResponseMessage? result = _handler?.ParseResponseToXML(responseByte);
            //Assert
            Assert.That(result?.Body?.Result, Is.EqualTo(responseObject.Body.Result));
        }
        [Test]

        public void DeserializeByteToXmlString_ReturnsValidXMLString()
        {
            //Arrange
            string responseXml = "EZE-XML-Msg02<Message>\r\n  " +
                "<Header>\r\n    " +
                "<MessageDate>20100324</MessageDate>\r\n    " +
                "<MessageTime>192806</MessageTime>\r\n  " +
                "</Header>\r\n  " +
                "<Body>\r\n    " +
                "<TransactionID>332527</TransactionID>\r\n    " +
                "<TransactionNumber>1210470</TransactionNumber>\r\n    " +
                "<PhoneNumber>639999999999</PhoneNumber>\r\n    " +
                "<Amount>0000002500</Amount>\r\n    " +
                "<Result>03</Result>\r\n  " +
                "</Body>\r\n</Message>";
            byte[] responseByte = Encoding.Default.GetBytes((string)responseXml);
            //Act
            var result = _handler?.DeserializeByteToXmlString(responseByte);
            //Assert
            Assert.That(result, Is.EqualTo(responseXml));
        }

        [Test]
        public void parseResultCode_ReturnsSuccess()
        {
            //Arrange
            ResponseMessage response = new ResponseMessage
            {
                Body = new ResponseMessageBody
                {
                    Result = "01"
                }
            };
            //Act
            var result = _handler?.parseResultCode(response);
            //Assert
            Assert.That(result, Is.EqualTo("Success"));
        }
        [Test]
        public void parseResultCode_ReturnsFailure()
        {
            //Arrange
            ResponseMessage response = new ResponseMessage
            {
                Body = new ResponseMessageBody
                {
                    Result = "99"
                }
            };
            //Act
            var result = _handler?.parseResultCode(response);
            //Assert
            Assert.That(result, Is.EqualTo("Failure"));
        }
        [Test]
        public void parseResultCode_ReturnsInvalidMessage()
        {
            //Arrange
            ResponseMessage response = new ResponseMessage
            {
                Body = new ResponseMessageBody
                {
                    Result = "999"
                }
            };
            //Act
            var result = _handler?.parseResultCode(response);
            //Assert
            Assert.That(result, Is.EqualTo("Invalid Message"));
        }
        [Test]
        public void parseResultCode_ReturnsUnknown()
        {
            //Arrange
            ResponseMessage response = new ResponseMessage
            {
                Body = new ResponseMessageBody
                {
                    Result = "100"
                }
            };
            //Act
            var result = _handler?.parseResultCode(response);
            //Assert
            Assert.That(result, Is.EqualTo("Unknown result code"));
        }

        [Test]
        public void parseResultCode_InputNull_ReturnsUnknown()
        {
            //Arrange
            ResponseMessage? response = null;
            //Act
            var result = _handler?.parseResultCode(response);
            //Assert
            Assert.That(result, Is.EqualTo("Unknown result code"));
        }
    }
}
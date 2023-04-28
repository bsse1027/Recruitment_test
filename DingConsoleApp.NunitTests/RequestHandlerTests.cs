namespace DingConsoleApp.NunitTests
{
    public class RequestHandlerTests
    {
        private RequestHandler? _handler;
        [SetUp]
        public void Setup()
        {
            _handler = new RequestHandler();
        }

        [Test]
        public void BuildRequestMessage_ValidRequest_ReturnsByteArray()
        {
            //Arrange
            string phoneNumber = "123456789";
            string currAmount = "50";
            //Act
            byte[]? result = _handler?.BuildRequestMessage(phoneNumber, currAmount);
            //Assert
            Assert.IsInstanceOf(typeof(byte[]), result);
        }
        [Test]
        public void BuildRequestMessage_InvalidPhoneNumber_ReturnsNull()
        {
            //Arrange
            string phoneNumber = "12345678912345";
            string currAmount = "50";
            //Act
            byte[]? result = _handler?.BuildRequestMessage(phoneNumber, currAmount);
            //Assert
            Assert.That(result, Is.EqualTo(null));
        }

        [Test]
        public void BuildRequestMessage_InvalidAmount_ReturnsNull()
        {
            //Arrange
            string phoneNumber = "123456789";
            string currAmount = "50.50";
            //Act
            byte[]? result = _handler?.BuildRequestMessage(phoneNumber, currAmount);
            //Assert
            Assert.That(result, Is.EqualTo(null));
        }
    }
}
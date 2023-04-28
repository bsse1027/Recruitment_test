using System;

namespace DingConsoleAppSource
{
    public class TestDriver
    {
        static void Main(string[] args)
        {
            RequestHandler reqHandler = new RequestHandler();
            ResponseHandler responseHandler = new ResponseHandler();
            string phoneNumber, amount;
            int transcation = 1;

            //Sample Request 1 to the Partner X API
            //An XML request message will be built with the phone number and amount and convert it into a byte stream
            //This byte stream will be sent to the actual api through an endpoint url after null check
            phoneNumber = "630000000000";
            amount = "25";
            byte[]? reqMsg1 = reqHandler.BuildRequestMessage(phoneNumber, amount);
            if(reqMsg1 != null)
            {
                Console.WriteLine($"Transcation Sample {transcation++}\nPhone Number : {phoneNumber}\nRecharge Amount: {amount}");
            }

            /*Sample Response 1 from Partnert X Api
            *   A byte array response will be accepted from PartnerXApi after a request has been processed
            *   The response will be parsed into a response message object for further querying
            *   We are assuming that response will only come when request message is valid and not null 
            */
            byte[] response1 = { 69, 90, 69, 45, 88, 77, 76, 45, 77, 115, 103, 48, 50, 60, 77, 101, 115, 115, 97, 103, 101, 62, 13, 10, 32, 32, 60, 72, 101, 97, 100, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103, 101, 68, 97, 116, 101, 62, 50, 48, 49, 48, 48, 51, 50, 52, 60, 47, 77, 101, 115, 115, 97, 103, 101, 68, 97, 116, 101, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103, 101, 84, 105, 109, 101, 62, 49, 57, 50, 54, 48, 50, 60, 47, 77, 101, 115, 115, 97, 103, 101, 84, 105, 109, 101, 62, 13, 10, 32, 32, 60, 47, 72, 101, 97, 100, 101, 114, 62, 13, 10, 32, 32, 60, 66, 111, 100, 121, 62, 13, 10, 32, 32, 32, 32, 60, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 51, 51, 50, 53, 50, 54, 60, 47, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 13, 10, 32, 32, 32, 32, 60, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 78, 117, 109, 98, 101, 114, 62, 49, 50, 49, 48, 52, 53, 50, 60, 47, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 78, 117, 109, 98, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 80, 104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 54, 51, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 60, 47, 80, 104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 65, 109, 111, 117, 110, 116, 62, 48, 48, 48, 48, 48, 48, 50, 53, 48, 48, 60, 47, 65, 109, 111, 117, 110, 116, 62, 13, 10, 32, 32, 32, 32, 60, 82, 101, 115, 117, 108, 116, 62, 48, 49, 60, 47, 82, 101, 115, 117, 108, 116, 62, 13, 10, 32, 32, 60, 47, 66, 111, 100, 121, 62, 13, 10, 60, 47, 77, 101, 115, 115, 97, 103, 101, 62 };
            var response1Xml =  responseHandler.ParseResponseToXML(response1);
            if(reqMsg1 != null)
            {
                Console.WriteLine($"Response Code For Sample Response 1:");
                Console.WriteLine($"Result Code is: {response1Xml?.Body?.Result} and status is : {responseHandler.parseResultCode(response1Xml)}");
                Console.WriteLine($"Raw XML Response:\n {responseHandler.DeserializeByteToXmlString(response1)}");
            }

            Console.WriteLine("---------------------------------------------------");

            //Sample Request 2 to the Partner X API
            phoneNumber = "639999999999";
            amount = "25";
            byte[]? reqMsg2 = reqHandler.BuildRequestMessage(phoneNumber, amount);
            if (reqMsg2 != null)
            {
                Console.WriteLine($"Transcation Sample {transcation++}\nPhone Number : {phoneNumber}\nRecharge Amount: {amount}");
            }

            //Sample Response 2 from Partnert X Api
            
            byte[] response2 = { 69, 90, 69, 45, 88, 77, 76, 45, 77, 115, 103, 48, 50, 60, 77, 101, 115, 115, 97, 103, 101, 62, 13, 10, 32, 32, 60, 72, 101, 97, 100, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103, 101, 68, 97, 116, 101, 62, 50, 48, 49, 48, 48, 51, 50, 52, 60, 47, 77, 101, 115, 115, 97, 103, 101, 68, 97, 116, 101, 62, 13, 10, 32, 32, 32, 32, 60, 77, 101, 115, 115, 97, 103, 101, 84, 105, 109, 101, 62, 49, 57, 50, 56, 48, 54, 60, 47, 77, 101, 115, 115, 97, 103, 101, 84, 105, 109, 101, 62, 13, 10, 32, 32, 60, 47, 72, 101, 97, 100, 101, 114, 62, 13, 10, 32, 32, 60, 66, 111, 100, 121, 62, 13, 10, 32, 32, 32, 32, 60, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 51, 51, 50, 53, 50, 55, 60, 47, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 73, 68, 62, 13, 10, 32, 32, 32, 32, 60, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 78, 117, 109, 98, 101, 114, 62, 49, 50, 49, 48, 52, 55, 48, 60, 47, 84, 114, 97, 110, 115, 97, 99, 116, 105, 111, 110, 78, 117, 109, 98, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 80, 104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 54, 51, 57, 57, 57, 57, 57, 57, 57, 57, 57, 57, 60, 47, 80, 104, 111, 110, 101, 78, 117, 109, 98, 101, 114, 62, 13, 10, 32, 32, 32, 32, 60, 65, 109, 111, 117, 110, 116, 62, 48, 48, 48, 48, 48, 48, 50, 53, 48, 48, 60, 47, 65, 109, 111, 117, 110, 116, 62, 13, 10, 32, 32, 32, 32, 60, 82, 101, 115, 117, 108, 116, 62, 48, 51, 60, 47, 82, 101, 115, 117, 108, 116, 62, 13, 10, 32, 32, 60, 47, 66, 111, 100, 121, 62, 13, 10, 60, 47, 77, 101, 115, 115, 97, 103, 101, 62 };
            var response2Xml = responseHandler.ParseResponseToXML(response2);
            if(reqMsg2 != null)
            {
                Console.WriteLine($"Response Code For Sample Response 2:");
                Console.WriteLine($"Result Code is: {response2Xml?.Body?.Result} and status is : {responseHandler.parseResultCode(response2Xml)}");
                Console.WriteLine($"Raw XML Response:\n {responseHandler.DeserializeByteToXmlString(response2)}");
            }
        }
    }
}
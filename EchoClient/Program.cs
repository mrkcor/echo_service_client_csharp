using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // message is the message to send to the EchoService
            String message;
            // If command line arguments were given then the first argument is used
            // to send to the EchoService, otherwise "Hello from C#" is used as the default
            if (args.Count() > 0) {
                message = args[0];
            } else {
                message = "Hello from C#";
            }

            // Instantiate new EchoService client
            Echo.EchoPortTypeClient client = new Echo.EchoPortTypeClient();

            // Define the request object and set the message within it
            //
            // Because the same XML types are used for both the Echo and 
            // ReverseEcho operation in the XML schema VisualStudio uses
            // the same classes for the request and response for both 
            // operations. In this example the request is set once and
            // is used for calling both Echo and ReverseEcho, and the
            // same response variable is used to capture the response
            // for both calls.
            // Most services that offer multiple operations will use
            // different XML types for different operations, so you
            // will not always be able to reuse request and response
            // variables between operations like done in this example
            Echo.EchoMessageType request = new Echo.EchoMessageType();
            request.Message = message;

            // Define the response object
            Echo.EchoMessageType response;

            try
            {
                // Call Echo and output the result
                response = client.Echo(request);
                Console.WriteLine("EchoService responsed to Echo: " + response.Message);
            } catch (System.ServiceModel.CommunicationException exception) {
                // In case of an error (SOAP fault or otherwise) output the error
                Console.WriteLine("An error occurred while calling Echo on the EchoService: " + exception.Message);
            }

            try
            {
                // Call ReverseEcho and output the result
                response = client.ReverseEcho(request);
                Console.WriteLine("EchoService responsed to ReverseEcho: " + response.Message);
            }
            catch (System.ServiceModel.CommunicationException exception)
            {
                // In case of an error (SOAP fault or otherwise) output the error
                Console.WriteLine("An error occurred while calling ReverseEcho on the EchoService: " + exception.Message);
            }
        }
    }
}

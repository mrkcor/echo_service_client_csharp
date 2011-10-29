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
            String message;
            if (args.Count() > 0) {
                message = args[0];
            } else {
                message = "Hello from C#";
            }

            Echo.EchoPortTypeClient client = new Echo.EchoPortTypeClient();
            Echo.EchoMessageType request = new Echo.EchoMessageType();
            request.Message = message;

            try
            {
                Echo.EchoMessageType response = client.Echo(request);
                Console.WriteLine("EchoService said: " + response.Message);
            } catch (System.ServiceModel.FaultException sf) {
                Console.WriteLine("SOAP fault: " + sf.Message);
            }
        }
    }
}

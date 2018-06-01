using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;

namespace ServiceBusHelloWorld
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://tempservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=qRFXfaSjUNcDNJkf6wbdZD9OMJTBZGjWWMBHq/UIhnM=";
        const string QueueName = "queue1";

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            const int numberOfMessages = 10;
            ISenderClient queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            ISenderClient topicClient = new TopicClient(ServiceBusConnectionString, "topic1");

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            await SendMessagesAsync(queueClient, numberOfMessages);
            await SendMessagesAsync(topicClient, numberOfMessages);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }

        static async Task SendMessagesAsync(ISenderClient client, int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the queue.
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console.
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the queue.
                    await client.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}

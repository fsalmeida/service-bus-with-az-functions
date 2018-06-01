using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsHelloWorld
{
    public static class ProcessSBQueue1Function
    {
        [FunctionName("ProcessSBQueue1Function")]
        public static void Run([ServiceBusTrigger("queue1", Connection = "SB")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}

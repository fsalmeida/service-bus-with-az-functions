using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsHelloWorld
{
    public static class ProcessSBTopic1FirstSubscriptionFunction
    {
        [FunctionName("ProcessSBTopic1FirstSubscriptionFunction")]
        public static void Run([ServiceBusTrigger("topic1", "FirstSubscription", Connection = "SB")]string mySbMsg, TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}

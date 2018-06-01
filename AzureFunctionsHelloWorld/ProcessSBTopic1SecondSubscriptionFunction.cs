using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace AzureFunctionsHelloWorld
{
    public static class ProcessSBTopic1SecondSubscriptionFunction
    {
        [FunctionName("ProcessSBTopic1SecondSubscriptionFunction")]
        public static void Run([ServiceBusTrigger("topic1", "SecondSubscription", Connection = "SB")]string mySbMsg, TraceWriter log)
        {
            log.Info($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}

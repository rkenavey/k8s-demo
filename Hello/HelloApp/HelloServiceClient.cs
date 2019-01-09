using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HelloApp
{
    public interface IHelloServiceClient
    {
        Task<string> GetMessage(string name);
    }

    public class HelloServiceClient : IHelloServiceClient
    {
        private readonly HttpClient _httpClient;

        // TODO: Service discovery
        //private static readonly Uri HelloServiceEndpoint = new Uri(@"https://localhost:5001/hello/"); // local
        private static readonly Uri HelloServiceEndpoint = new Uri(@"http://172.19.0.2/hello/");        // Docker (myHelloService doesn't resolve)

        public HelloServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> GetMessage(string name)
        {
            var uri = new Uri(HelloServiceEndpoint, name);
            Console.WriteLine($"Calling {uri}");
            return await _httpClient.GetStringAsync(uri);
        }
    }
}

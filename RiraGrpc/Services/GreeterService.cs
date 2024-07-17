using Grpc.Core;
using RiraGrpc;

namespace RiraGrpc.Services
{
    public class GreeterService : Greeter.GreeterBase
    {

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            var x = request.Time;
            DateTime date = new DateTime(x.Year, x.Month, x.Day);
            

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}

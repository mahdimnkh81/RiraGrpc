using Grpc.Core;
using Rira.Application.Contract.Customer;
using RiraGrpc.Protos;

namespace RiraGrpc.Services
{
    public class CustomerService : CustomerCrud.CustomerCrudBase
    {
        private readonly ICustomerApplication customerApplication;

        public CustomerService(ICustomerApplication customerApplication)
        {
            this.customerApplication = customerApplication;
        }

        public override async Task<CreateCustomerResponse> Create(CreateCustomerRequest request,
            ServerCallContext context)
        {
            if (request.Name == string.Empty || request.Family == string.Empty ||
                request.NationalNumber == string.Empty)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply a valid object"));
            var birthday = new DateTime(request.Birthday.Year, request.Birthday.Month, request.Birthday.Day);
            var cus = new CreateCustomer
            {
                Name = request.Name,
                Family = request.Family,
                NationalNumber = request.NationalNumber,
                Birthday = birthday
            };
            customerApplication.Create(cus);

            return await Task.FromResult(new CreateCustomerResponse
            {
                Response = "OK"
            });
        }

        public override async Task<ReadCustomerResponse> Read(ReadCustomerRequest request, ServerCallContext context)
        {
            if (request.Id <= 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "resource index must be greater than 0"));

            var cus = customerApplication.Get(request.Id);


            if (cus != null)
            {
                return await Task.FromResult(new ReadCustomerResponse
                {
                    Id = cus.Id,
                    Name = cus.Name,
                    Family = cus.Family,
                    NationalNumber = cus.NationalNumber,
                    Birthday = new Protos.Date
                    {
                        Year = cus.Birthday.Year,
                        Month = cus.Birthday.Month,
                        Day = cus.Birthday.Day
                    }
                });
            }

            throw new RpcException(new Status(StatusCode.NotFound, $"No Task with id {request.Id}"));
        }

        public override async Task<GetAllResponse> List(GetAllRequest request, ServerCallContext context)
        {
            var response = new GetAllResponse();
            var customerItems = await customerApplication.GetAll();

            foreach (var cus in customerItems)
            {
                response.Customers.Add(new ReadCustomerResponse
                {
                    Id = cus.Id,
                    Name = cus.Name,
                    Family = cus.Family,
                    NationalNumber = cus.NationalNumber,
                    Birthday = new Protos.Date
                    {
                        Year = cus.Birthday.Year,
                        Month = cus.Birthday.Month,
                        Day = cus.Birthday.Day
                    }
                });
            }

            return await Task.FromResult(response);
        }

        public override async Task<UpdateCustomerResponse> Update(UpdateCustomerRequest request,
            ServerCallContext context)
        {
            if (request.Name == string.Empty || request.Family == string.Empty ||
                request.NationalNumber == string.Empty)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "You must supply a valid object"));

            var cusUpdated = new EditCustomer
            {
                Id =  request.Id,
                Name = request.Name,
                Family = request.Family,
                NationalNumber = request.NationalNumber,
                Birthday = new DateTime(request.Birthday.Year, request.Birthday.Month, request.Birthday.Day)

            };
            customerApplication.Update(cusUpdated);


            return await Task.FromResult(new UpdateCustomerResponse
            {
                Response = "OK"
            });
        }

        public override async Task<DeleteCustomerResponse> Delete(DeleteCustomerRequest request, ServerCallContext context)
        {
            if (request.Id <= 0)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "resource index must be greater than 0"));

            var cusDelete = customerApplication.Delete(request.Id);

            return await Task.FromResult(new DeleteCustomerResponse
            {
                Response = "OK"
            });

        }
    }
}
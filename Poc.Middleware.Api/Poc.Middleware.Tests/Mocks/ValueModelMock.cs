using AutoBogus;
using Bogus;
using Poc.Middleware.Api.Domain.Model;

namespace Poc.Middleware.Tests.Mocks
{
    public static class ValueModelMock
    {
        public static Faker<ValueModel> Fake => new AutoFaker<ValueModel>();
    }
}

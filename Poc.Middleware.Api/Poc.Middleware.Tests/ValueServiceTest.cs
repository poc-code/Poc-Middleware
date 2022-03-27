using FluentAssertions;
using Poc.Middleware.Api.Domain.Model;
using Poc.Middleware.Api.Service;
using Poc.Middleware.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Poc.Middleware.Tests
{
    public class ValueServiceTest
    {
        private readonly ValueService _service;

        public ValueServiceTest()
        {
            _service = new ValueService();
        }

        [Fact]
        public void add_shoud_be_return_list()
        {
            // arrange 
            var model = ValueModelMock.Fake.Generate();

            // act
            var result = _service.Add(model);

            // assert
            Assert.Equal(model,result.FindLast(x => x.GuiId.Equals(model.GuiId)));
            result.Should().NotBeNull().And.BeAssignableTo<List<ValueModel>>();

        }

        [Fact]
        public void update_shoud_be_return_one()
        {
            // arrange 
            var modelupdate = _service.GetAll().LastOrDefault();
            var model = ValueModelMock.Fake.Generate();

            model.GuiId = modelupdate.GuiId;

            // act
            var result = _service.Update(model);

            // assert
            Assert.Equal(model, result);
            result.Should().NotBeNull().And.BeAssignableTo<ValueModel>();
        }

        [Fact]
        public void update_shoud_be_null_model_exception()
        {
            // arrange 
            var model = null as ValueModel;

            //act

            Action action = () => _service.Update(model);

            // assert
            var caughtException = Assert.Throws<InvalidOperationException>(action);
            Assert.Equal("item não fornecido", caughtException.Message);
        }

        [Fact]
        public void update_shoud_be_not_found_exception()
        {
            // arrange 
            var model = ValueModelMock.Fake.Generate();

            //act

            Action action = () => _service.Update(model);

            // assert
            var caughtException = Assert.Throws<Exception>(action);
            Assert.Equal("item não encontrado", caughtException.Message);
        }


        [Fact]
        public void remove_shoud_be_return_one()
        {
            // arrange 
            var model = _service.GetAll().LastOrDefault();

            // act
            var result = _service.Remove(model);
            var findModel = _service.GetById(model.GuiId);

            // assert
            Assert.Null(findModel);
            result.Should().NotBeNull().And.BeAssignableTo<List<ValueModel>>();
        }
    }
}
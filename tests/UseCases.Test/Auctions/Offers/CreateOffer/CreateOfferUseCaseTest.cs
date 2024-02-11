using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auctions.API.Contracts;
using Auctions.API.Dtos.Requests;
using Auctions.API.Entities;
using Auctions.API.Services;
using Auctions.API.UseCases.Auctions.GetCurrent;
using Auctions.API.UseCases.Offers.CreateOffer;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCases.Test.Auctions.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Success(int itemId)
        {
            //ARRANGE
            var request = new Faker<RequestCreateOfferDto>()
                .RuleFor(auction => auction.Price, faker => faker.Random.Decimal(1, 700)).Generate();

            var mockedOfferRepository = new Mock<IOfferRepository>();
            var mockedLoggedUser = new Mock<ILoggedUser>();
            mockedLoggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(mockedLoggedUser.Object, mockedOfferRepository.Object);

            //ACT
            var act = () => useCase.Execute(itemId, request);

            //ASSERT
            act.Should().NotThrow();
        }
    }
}

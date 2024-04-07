using System;
using CommercialWebsite.DataContext.Concrete;
using CommercialWebsite.DataContext.Dto;
using CommercialWebsite.DataContext.Interface;
using Moq;

namespace CommercialWebsite.DataContext.Tests.Concrete
{
    public class Render
    {
        private readonly IWebsiteFieldRepository _websiteFieldRepository;

        public Render(IWebsiteFieldRepository websiteFieldRepository)
        {
            this._websiteFieldRepository = websiteFieldRepository;
        }

        public string[] ReturnMenuTexts()
        {
            string home = this._websiteFieldRepository.GetTextByNameAndLang("menu__home", "tr");
            string clients = this._websiteFieldRepository.GetTextByNameAndLang("menu__clients", "tr");

            return new string[]
            {
                home,
                clients
            };
        }
    }

    public class ClientRepositoryTests
    {

        [Fact]
        public void Render_ShouldReturnCorrectValues()
        {
            // Arrange
            const string homeText = "TEST_home_TEXT";
            const string clientsText = "TEST_clie_n_ts_TEXT";

            Mock<IWebsiteFieldRepository> mockWebsiteFieldRepository = new Mock<IWebsiteFieldRepository>();
            mockWebsiteFieldRepository.Setup(o => o.GetTextByNameAndLang("menu__home", "tr")).Returns(homeText);
            mockWebsiteFieldRepository.Setup(o => o.GetTextByNameAndLang("menu__clients", "tr")).Returns(clientsText);

            Render render = new Render(mockWebsiteFieldRepository.Object);

            // Act
            string[] result = render.ReturnMenuTexts();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal(homeText, result[0]);
            Assert.Equal(clientsText, result[1]);
        }

        [Fact]
        public void ClientRepository_ShouldGetAllClientsCorrectly()
        {
            // Arrange
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration("../../../Database");
            ClientRepository clientRepository = new ClientRepository(databaseConfiguration);

            // Act
            IEnumerable<ClientDto> clientDtos = clientRepository.GetAll();

            // Assert
            Assert.Equal(7, clientDtos.Count());
            Assert.Equal("KUZEY BORU", clientDtos.Skip(2).First().Name);
            Assert.Equal("https://mavipiksel.com/wp-content/uploads/2018/06/2021-10-27-550x550.jpg", clientDtos.Skip(2).First().ImgLink);
        }
    }
}
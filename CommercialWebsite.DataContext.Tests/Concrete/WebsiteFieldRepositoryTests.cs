using System;
using CommercialWebsite.DataContext.Concrete;
using CommercialWebsite.DataContext.Dto;

namespace CommercialWebsite.DataContext.Tests.Concrete
{
    public class WebsiteFieldRepositoryTests
    {
        [Theory]
        [InlineData("menu__home", "tr", "Ana Sayfa")]
        [InlineData("menu__home", "en", "Home")]
        [InlineData("page_clients__section_all", "tr", "Tümü")]
        [InlineData("page_clients__section_all", "en", "All")]
        [InlineData("page_clients__title", "tr", "ÇALIŞMALARIMIZ")]
        [InlineData("page_clients__title", "en", "CLIENTS")]
        public void WebsiteFieldRepository_ShouldReturnCorrectTextByNameAndLanguage(string name, string language, string expectedText)
        {
            // Arrange
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration("../../../Database");
            WebsiteFieldRepository websiteFieldRepository = new WebsiteFieldRepository(databaseConfiguration);

            // Act
            string resultText = websiteFieldRepository.GetTextByNameAndLang(name, language);

            // Assert
            Assert.Equal(expectedText, resultText);
        }

        [Theory]
        [InlineData("menu__home2", "tr")]
        [InlineData("menu__home", "tr2")]
        [InlineData("sdfsdf", "tr")]
        [InlineData("page_clients__section_all", "du")]
        public void WebsiteFieldRepository_ShouldReturnNullForIncorrectNameOrLanguage(string name, string language)
        {
            // Arrange
            DatabaseConfiguration databaseConfiguration = new DatabaseConfiguration("../../../Database");
            WebsiteFieldRepository websiteFieldRepository = new WebsiteFieldRepository(databaseConfiguration);

            // Act
            string resultText = websiteFieldRepository.GetTextByNameAndLang(name, language);

            // Assert
            Assert.Null(resultText);
        }
    }
}
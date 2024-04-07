using System;
using CommercialWebsite.DataContext.Dto;

namespace CommercialWebsite.DataContext.Interface
{
    public interface IWebsiteFieldRepository
    {
        string GetTextByNameAndLang(string name, string language);
    }
}
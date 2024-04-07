using System;
using CommercialWebsite.DataContext.Dto;

namespace CommercialWebsite.DataContext.Interface
{
    public interface IClientRepository
    {
        IEnumerable<ClientDto> GetAll();
    }
}
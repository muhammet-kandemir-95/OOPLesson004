using System;
using System.Text.Json.Serialization;
using CommercialWebsite.DataContext.Dto;
using CommercialWebsite.DataContext.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommercialWebsite.DataContext.Concrete
{
    public class ClientRepository : IClientRepository
    {
        public IDatabaseConfiguration DatabaseConfiguration { get; set; }

        public ClientRepository(IDatabaseConfiguration databaseConfiguration)
        {
            this.DatabaseConfiguration = databaseConfiguration;
        }

        public IEnumerable<ClientDto> GetAll()
        {
            List<ClientDto> clientDtos = new List<ClientDto>();

            string jsonText = File.ReadAllText(Path.Combine(this.DatabaseConfiguration.DatabaseFolderFilePath, "clients.json"));
            JArray dataJArray = JsonConvert.DeserializeObject<JArray>(jsonText);

            foreach (JToken row in dataJArray)
            {
                ClientDto clientDto = new ClientDto
                {
                    Name = row.Value<string>("name"),
                    ImgLink = row.Value<string>("img_link")
                };

                clientDtos.Add(clientDto);
            }

            return clientDtos;
        }
    }
}
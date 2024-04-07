using System;
using CommercialWebsite.DataContext.Dto;
using CommercialWebsite.DataContext.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CommercialWebsite.DataContext.Concrete
{
    public class WebsiteFieldRepository : IWebsiteFieldRepository
    {
        public IDatabaseConfiguration DatabaseConfiguration { get; set; }

        public WebsiteFieldRepository(IDatabaseConfiguration databaseConfiguration)
        {
            this.DatabaseConfiguration = databaseConfiguration;
        }

        public string GetTextByNameAndLang(string name, string language)
        {
            string jsonText = File.ReadAllText(Path.Combine(this.DatabaseConfiguration.DatabaseFolderFilePath, "website_fields.json"));
            JArray dataJArray = JsonConvert.DeserializeObject<JArray>(jsonText);

            foreach (JToken row in dataJArray)
            {
                if (row.Value<string>("name") == name && row.Value<string>("language") == language)
                {
                    return row.Value<string>("text");
                }
            }

            return null;
        }
    }
}
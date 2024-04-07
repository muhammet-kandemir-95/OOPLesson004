using System;

namespace CommercialWebsite.DataContext.Dto
{
    public record WebsiteFieldDto
    {
        public string Name { get; set; }
        public string Language { get; set; }
        public string Text { get; set; }
    }
}
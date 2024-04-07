using System;

namespace CommercialWebsite.DataContext.Dto
{
    public record ClientDto
    {
        public string Name { get; set; }
        public string ImgLink { get; set; }
    }
}
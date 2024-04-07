using System;
using CommercialWebsite.DataContext.Dto;

namespace CommercialWebsite.DataContext.Interface
{
    public interface IDatabaseConfiguration
    {
        string DatabaseFolderFilePath { get; }
    }
}
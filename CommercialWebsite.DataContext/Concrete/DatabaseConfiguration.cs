using System;
using CommercialWebsite.DataContext.Interface;

namespace CommercialWebsite.DataContext.Concrete
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string DatabaseFolderFilePath { get; set; }

        public DatabaseConfiguration(string databaseFolderFilePath)
        {
            this.DatabaseFolderFilePath = databaseFolderFilePath;
        }
    }
}
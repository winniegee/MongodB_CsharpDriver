using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PeopleStoreSettings: IPeopleStoreSettings
    {
        public string PeopleCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPeopleStoreSettings
    {
        string PeopleCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    
    }
}

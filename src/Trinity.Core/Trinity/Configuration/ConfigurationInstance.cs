using System;

namespace Trinity.Configuration
{
    internal class ConfigurationInstance
    {
        public ConfigurationInstance(object singleton_instance, string entry_name, System.Type type)
        {
            this.Instance = singleton_instance;
            this.EntryName = entry_name;
            this.Type = type;
        }
        public string EntryName { get; set; }
        public object Instance { get; set; }
        public Type Type { get; set; }
    }
}

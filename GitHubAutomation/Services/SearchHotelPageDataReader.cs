using System;
using System.Configuration;

namespace AirAsiaAutomation.Services
{
    public static class SearchHotelPageDataReader
    {
        static Configuration ConfigFile
        {
            get
            {
                string file = "searchHotelPageInfo";
                int index = AppDomain.CurrentDomain.BaseDirectory.IndexOf("bin", StringComparison.Ordinal);
                var configeMap = new ExeConfigurationFileMap
                {
                    ExeConfigFilename = AppDomain.CurrentDomain.BaseDirectory.Substring(0, index) +
                    @"Configs\" + file + ".config"
                };
                Logger.Log.Info("Hotel booking data got");
                return ConfigurationManager.OpenMappedExeConfiguration(configeMap, ConfigurationUserLevel.None);
            }
        }

        public static string GetData(string key)
        {
            return ConfigFile.AppSettings.Settings[key].Value;
        }
    }
}

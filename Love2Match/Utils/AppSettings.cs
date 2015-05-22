using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;

namespace Love2Match.Utils
{
    class AppSettings
    {


        IsolatedStorageSettings settings;

        // Settings key names
        const string ConvertionModeKeyName = "ConvertionModeSetting";
        const string SearchLanguageKeyName = "SearchLanguageSetting";
        const string NumberInclusionKeyName = "NumberInclusionSetting";

        // Settings default values
        const string ConvertionModeDefault = "number2word";
        const string SearchLanguageDefault = "en";
        const bool NumberInclusionDefault = false;


        /// <summary>
        /// Constructor that gets the application settings.
        /// </summary>
        public AppSettings()
        {
            // Get the settings for this application.
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        /// <summary>
        /// Update a setting value for our application. If the setting does not
        /// exist, then add the setting.
        /// </summary>
        /// <param name="Key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }



        /// <summary>
        /// Property to get and set the Convertion Mode Setting Key
        /// </summary>
        public string ConvertionModeSetting
        {

            get
            {
                return GetValueOrDefault<string>(ConvertionModeKeyName, ConvertionModeDefault);
            }

            set
            {
                if (AddOrUpdateValue(ConvertionModeKeyName, value))
                    Save();
            }
        }



        /// <summary>
        /// Property to get and set the Search Language Setting Key
        /// </summary>
        public string SearchLanguageSetting
        {

            get
            {
                return GetValueOrDefault<string>(SearchLanguageKeyName, SearchLanguageDefault);
            }

            set
            {
                if (AddOrUpdateValue(SearchLanguageKeyName, value))
                    Save();
            }
        }



        /// <summary>
        /// Property to get and set the Search Language Setting Key
        /// </summary>
        public bool NumberInclusion
        {
            get
            {
                return GetValueOrDefault<bool>(NumberInclusionKeyName, NumberInclusionDefault);
            }

            set
            {
                if (AddOrUpdateValue(NumberInclusionKeyName, value))
                    Save();
            }
        }



    }
}

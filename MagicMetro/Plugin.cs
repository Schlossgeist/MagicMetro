using Schlossgeist.MagicMetro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface musicBee;
        private PluginInfo info = new PluginInfo();
        private MagicMetro magicMetro;

        public ConfigPanel configPanel;

        public PluginInfo Initialise(IntPtr apiPtr)
        {
            musicBee = new MusicBeeApiInterface();
            musicBee.Initialise(apiPtr);

            info.PluginInfoVersion = PluginInfoVersion;
            info.Name = "MagicMetro";
            info.Description = "Custom Colorschemes for Metro Skins";
            info.Author = "Schlossgeist";
            info.TargetApplication = "MusicBee";
            info.Type = PluginType.General;
            info.VersionMajor = 1;
            info.VersionMinor = 0;
            info.Revision = 0;
            info.MinInterfaceVersion = 20;
            info.MinApiRevision = 25;
            info.ReceiveNotifications = ReceiveNotificationFlags.StartupOnly;
            info.ConfigurationPanelHeight = 300;

            try
            {
                magicMetro = new MagicMetro(musicBee.Setting_GetPersistentStoragePath(), this);
            }
            catch (Exception e)
            {
                MessageBox.Show("An error occurred during plugin startup: " + e.Message);
                throw;
            }

            return info;
        }

        public void ReceiveNotification(String source, NotificationType type)
        {
            magicMetro.getLogger().Debug($"Received notification: {type}");
            switch (type)
            {
                case NotificationType.PluginStartup:
                    break;
                default:
                    break;
            }
        }

        public void Close(PluginCloseReason reason)
        {
            magicMetro.getLogger().Info("Plugin disabled");
            magicMetro.shutdown();
            magicMetro = null;
        }

        public void Uninstall()
        {
            magicMetro.getLogger().Info($"Uninstalling plugin");
            magicMetro.uninstall();
        }

        public bool Configure(IntPtr panelHandle)
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = musicBee.Setting_GetPersistentStoragePath();
            // panelHandle will only be set if you set about.ConfigurationPanelHeight to a non-zero value
            // keep in mind the panel width is scaled according to the font the user has selected
            // if about.ConfigurationPanelHeight is set to 0, you can display your own popup window
            if (panelHandle != IntPtr.Zero)
            {
                Panel mainPanel = (Panel) Panel.FromHandle(panelHandle);

                configPanel = new ConfigPanel(musicBee, mainPanel.Width);
                configPanel.reloadColors(magicMetro.colorDict);
                configPanel.extractButtonCallbackObject = magicMetro.extractImages;
                configPanel.customColorCallbackObject = magicMetro.onCustomColorChange;

                var items = new List<Tuple<string, string>>();
                foreach (var xmlcReplacement in magicMetro.getConfig().configuration.xmlcReplaceJobs ?? new List<Config.Configuration.XMLCReplacement>())
                    items.Add(new Tuple<string, string>(xmlcReplacement.sourcePath, xmlcReplacement.destinationPath));
                configPanel.setExtractionItems(items);

                configPanel.configDirCallbackObject = () => { System.Diagnostics.Process.Start(magicMetro.getConfig().configFile.Directory.FullName); };
                configPanel.setChosenColor(magicMetro.customColor);
                mainPanel.Controls.Add(configPanel);
            }

            return false;
        }

        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            magicMetro.getLogger().Info($"Saving settings");
            magicMetro.getConfig().writeCustomColorToConfig(magicMetro.customColor);
        }
    }
}

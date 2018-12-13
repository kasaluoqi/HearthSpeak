using Hearthstone_Deck_Tracker;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Plugins;
using Hearthstone_Deck_Tracker.Utility;
using Hearthstone_Deck_Tracker.Utility.HotKeys;
using Hearthstone_Deck_Tracker.Utility.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using HearthSpeak.menus;
using System.Speech.Recognition;
using System.Windows.Controls;

namespace HearthSpeak
{
    public class Program: IPlugin
    {
        public void OnLoad()
        {
            // Triggered upon startup and when the user ticks the plugin on
            runTask();
        }

        public void OnUnload()
        {
            // Triggered when the user unticks the plugin, however, HDT does not completely unload the plugin.
            // see https://git.io/vxEcH
        }

        public void OnButtonPress()
        {
            // Triggered when the user clicks your button in the plugin list
        }

        public void OnUpdate()
        {
            // called every ~100ms
        }

        public string Name => "PLUGIN NAME";

        public string Description => "DESCRIPTION";

        public string ButtonText => "BUTTON TEXT";

        public string Author => "AUTHOR";

        public Version Version => new Version(0, 0, 1);

        public MenuItem MenuItem => null;

        public void runTask()
        {
            var HsRect = User32.GetHearthstoneRect(true);
            var Ratio = (4.0 / 3.0) / ((double)HsRect.Width / HsRect.Height);


            Config.InitializeLogFile();
            Console.WriteLine("Welcome to HearthSpeak!\n");
            if (Properties.Settings.Default.StartListeningAtLaunch)
            {
                var recognizer = new Recognizer(HsRect.Width, HsRect.Height);
                recognizer.ListenIO();
            }
            else new MainMenu(HsRect.Width, HsRect.Height);
        }
    }
}

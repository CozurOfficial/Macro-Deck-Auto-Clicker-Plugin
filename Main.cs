using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using CozurOfficial.AutoClicker.Actions;
using CozurOfficial.AutoClicker.GUI;
using CozurOfficial.AutoClicker.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using WindowsInput;
using CozurOfficial.AutoClicker.Utils;
using SuchByte.MacroDeck.Variables;
using System.Windows.Forms;
using SuchByte.MacroDeck;

namespace CozurOfficial.AutoClicker
{
    public static class PluginInstance
    {
        public static Main Main;
    }


    public class Main : MacroDeckPlugin
    {
        public static Main Instance;

        public InputSimulator InputSimulator = new InputSimulator();

        public System.Timers.Timer TickTimer;

        public Main()
        {
            Instance = this;
            PluginInstance.Main = this;
        }

        public override void Enable()
        {
            // Dil desteğini başlat
            PluginLanguageManager.Initialize();

            // Eylemleri başlat
            this.Actions = new List<PluginAction>
            {
               new ClickingCoordinates(),
               new ToggleVariable(),
            };

            // Fare konumunu her 500 milisaniyede bir güncelle
            this.TickTimer = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 100,
            };
            this.TickTimer.Elapsed += (sender, e) =>
            {
                // Fare konumunu al
                Point cursorPosition = Cursor.Position;

                // Fare konumunu güncelle
                VariableHelper.UpdateMouseCoordinates(cursorPosition);
            };
            this.TickTimer.Start();
        }
    }
}
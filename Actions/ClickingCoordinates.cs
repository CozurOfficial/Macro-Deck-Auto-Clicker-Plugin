using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using CozurOfficial.AutoClicker.GUI;
using CozurOfficial.AutoClicker.Language;
using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsInput;
using CozurOfficial.AutoClicker.Utils;

namespace CozurOfficial.AutoClicker.Actions
{
    public class ClickingCoordinates : PluginAction
    {
        private bool isRunning = false;
        private Point targetPosition;
        private int repeaterInterval;

        public override string Name => PluginLanguageManager.PluginStrings.ClickingCoordinates;

        public override string Description => PluginLanguageManager.PluginStrings.ClickingCoordinatesDescription;

        public override bool CanConfigure => true;

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new ClickingCoordinatesConfigurator(this, actionConfigurator);
        }

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            try
            {
                if (this.Configuration != null && this.Configuration.Length > 0)
                {
                    JObject jObject = JObject.Parse(this.Configuration);
                    if (jObject != null)
                    {
                        int x = Convert.ToInt32(jObject["mouseX"]);
                        int y = Convert.ToInt32(jObject["mouseY"]);
                        bool leftClick = (bool)jObject["leftClick"];
                        bool rightClick = (bool)jObject["rightClick"];
                        int interval = (int)jObject["repeaterInterval"];
                        bool repeater = (bool)jObject["repeater"];

                        Cursor.Position = new Point(x, y);

                        if (leftClick)
                        {
                            MouseOperations.LeftClick();
                        }

                        if (rightClick)
                        {
                            MouseOperations.RightClick();
                        }

                            if (!isRunning && repeater)
                        {
                            // Çalışma durumuna geçir
                            isRunning = true;
                            targetPosition = new Point(x, y);
                            repeaterInterval = interval;

                            RepeatAction(clientId, actionButton, leftClick, rightClick);
                        }
                        else
                        {
                            // Durma durumuna geçir
                            isRunning = false;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata oluştu: " + ex.Message);
            }
        }

        private async void RepeatAction(string clientId, ActionButton actionButton, bool leftClick, bool rightClick)
        {
            while (isRunning)
            {
                Cursor.Position = targetPosition;

                if (leftClick)
                {
                    MouseOperations.LeftClick();
                }

                if (rightClick)
                {
                    MouseOperations.RightClick();
                }

                await System.Threading.Tasks.Task.Delay(repeaterInterval);
            }
        }
    }
}
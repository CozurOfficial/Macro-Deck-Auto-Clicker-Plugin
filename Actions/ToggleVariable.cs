using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using CozurOfficial.AutoClicker.GUI;
using CozurOfficial.AutoClicker.Language;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WindowsInput;
using System.Drawing;
using System.Windows.Forms;
using CozurOfficial.AutoClicker.Utils;

namespace CozurOfficial.AutoClicker.Actions
{
    public class ToggleVariable : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ToggleVariable;

        public override string Description => PluginLanguageManager.PluginStrings.ToggleVariableDescription;

        public override bool CanConfigure => false;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            // Toggle durumunu tersine çevir
            VariableHelper.ToggleUpdateStatus();
        }
    }
}

using System;
using System.Drawing;
using SuchByte.MacroDeck.Variables;

namespace CozurOfficial.AutoClicker.Utils
{
    public static class VariableHelper
    {
        private static bool isEnabled = false; // Toggle durumu

        public static void ToggleUpdateStatus()
        {
            isEnabled = !isEnabled; // Toggle durumunu tersine çevir
        }

        public static void UpdateMouseCoordinates(Point cursorPosition)
        {
            if (isEnabled) // Eğer toggle açıksa
            {
                // X ve Y koordinatlarını güncelle
                UpdateMouseX(cursorPosition.X);
                UpdateMouseY(cursorPosition.Y);
            }
        }

        private static void UpdateMouseX(int mouseX)
        {
            VariableManager.SetValue("Coordinates X", ("Mouse X",mouseX).ToString(), VariableType.String, PluginInstance.Main, null);
        }

        private static void UpdateMouseY(int mouseY)
        {
            VariableManager.SetValue("Coordinates Y", ("Mouse Y",mouseY).ToString(), VariableType.String, PluginInstance.Main, null);
        }
    }
}

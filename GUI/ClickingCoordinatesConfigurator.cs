using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using CozurOfficial.AutoClicker.Actions;
using System;
using System.Windows.Forms;
using CozurOfficial.AutoClicker.Language;

namespace CozurOfficial.AutoClicker.GUI
{
    public partial class ClickingCoordinatesConfigurator : ActionConfigControl
    {
        private ClickingCoordinates pluginAction;

        private bool isRunning = false;


        public ClickingCoordinatesConfigurator(ClickingCoordinates pluginAction, ActionConfigurator actionConfigurator)
        {
            this.pluginAction = pluginAction;
            InitializeComponent();

            LoadConfig();
            StartTrackingMousePosition();
        }

        public override bool OnActionSave()
        {
            // Mouse X ve Y koordinatlarını al
            int mouseX = int.Parse(textBoxCoordinateX.Text);
            int mouseY = int.Parse(textBoxCoordinateY.Text);

            // Sol ve sağ tıklama seçeneklerini al
            bool leftClick = chkLeftClick.Checked;
            bool rightClick = chkRightClick.Checked;
            bool repeater = chkRepeater.Checked;

            // Yapılandırmayı kaydet
            JObject configuration = new JObject();
            configuration["mouseX"] = mouseX;
            configuration["mouseY"] = mouseY;
            configuration["leftClick"] = leftClick;
            configuration["rightClick"] = rightClick;
            configuration["repeater"] = repeater;

            // Tekrarlayıcı aralığını al, eğer değer girilmişse
            if (int.TryParse(textRepeater.Text, out int repeaterInterval))
            {
                configuration["repeaterInterval"] = repeaterInterval;
            }
            else
            {
                // Eğer değer girilmemişse otomatik olarak 0 al
                configuration["repeaterInterval"] = 0;
            }

            // Yapılandırmayı JSON formatına dönüştür
            string configJson = configuration.ToString();

            // Kaydedilen yapılandırmayı ana uygulamaya gönder
            this.pluginAction.Configuration = configJson;

            this.pluginAction.ConfigurationSummary =
                $"Mouse X: {textBoxCoordinateX.Text}, Mouse Y: {textBoxCoordinateY.Text}, {PluginLanguageManager.PluginStrings.TextLeftClick}: {chkLeftClick.Checked}, {PluginLanguageManager.PluginStrings.TextRightClick}: {chkRightClick.Checked}, {PluginLanguageManager.PluginStrings.TextChkRepeater}: {chkRepeater.Checked}, {PluginLanguageManager.PluginStrings.TextMilliseconds}: {repeaterInterval}";

            // Kaydetme işlemi başarılı oldu
            return true;
        }



        private void LoadConfig()
        {
            // Kaydedilmiş yapılandırmayı al
            string configJson = this.pluginAction.Configuration;

            // Eğer yapılandırma boşsa, varsayılan değerleri kullan
            if (string.IsNullOrEmpty(configJson))
            {
                chkLeftClick.Checked = false;
                chkRightClick.Checked = false;
                chkRepeater.Checked = false;
                return;
            }

            // JSON formatındaki yapılandırmayı JObject'e dönüştür
            JObject configuration = JObject.Parse(configJson);

            // Fare koordinatlarını ve tıklama seçeneklerini al
            int mouseX = (int)configuration["mouseX"];
            int mouseY = (int)configuration["mouseY"];
            int repeaterInterval = (int)configuration["repeaterInterval"];
            bool leftClick = (bool)configuration["leftClick"];
            bool rightClick = (bool)configuration["rightClick"];
            bool repeater = (bool)configuration["repeater"];

            // Kontrol elemanlarına yapılandırmadaki değerleri yükle
            textBoxCoordinateX.Text = mouseX.ToString();
            textBoxCoordinateY.Text = mouseY.ToString();
            textRepeater.Text = repeaterInterval.ToString();
            chkLeftClick.Checked = leftClick;
            chkRightClick.Checked = rightClick;
            chkRepeater.Checked = repeater;
        }
    }
}
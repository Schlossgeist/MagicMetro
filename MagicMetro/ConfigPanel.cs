using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MusicBeePlugin;

using IP = Schlossgeist.MagicMetro.ImageProcessing;

namespace Schlossgeist.MagicMetro
{
    public partial class ConfigPanel : UserControl
    {
        public delegate void extractButtonCallback();
        public delegate void customColorCallback(IP.Color color);
        public delegate void configDirCallback();

        public extractButtonCallback extractButtonCallbackObject;
        public customColorCallback customColorCallbackObject;
        public configDirCallback configDirCallbackObject;

        private readonly Plugin.MusicBeeApiInterface apiInterface;

        public ConfigPanel(Plugin.MusicBeeApiInterface apiInterface, int width)
        {
            InitializeComponent();
            Width = width;
            this.apiInterface = apiInterface;

            extractImagesButton.Click += (sender, args) => extractButtonCallbackObject();
            chooseColorButton.Click += (sender, args) =>
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    customColorPanel.BackColor = colorDialog.Color;
                    customColorCallbackObject(new IP.Color(colorDialog.Color));
                }
            };
            githubLinkLabel.LinkClicked += (sender, args) =>
            {
                System.Diagnostics.Process.Start("https://github.com/Schlossgeist/MagicMetro");
            };
            forumLinkLabel.LinkClicked += (sender, args) =>
            {
                System.Diagnostics.Process.Start("https://getmusicbee.com/forum/index.php?topic=40921.0");
            };
            configLinkLabel.LinkClicked += (sender, args) => configDirCallbackObject();

            extractionListView.Columns[0].Width = extractionListView.Width / 2;
            extractionListView.Columns[1].Width = extractionListView.Width / 2;

            #region ControlElementColors

            extractImagesButton.ForeColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            extractImagesButton.BackColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBackground));

            extractImagesButton.FlatAppearance.BorderColor = Color.FromArgb(
                apiInterface.Setting_GetSkinElementColour(
                    Plugin.SkinElement.SkinInputControl,
                    Plugin.ElementState.ElementStateDefault,
                    Plugin.ElementComponent.ComponentBorder));

            chooseColorButton.ForeColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            chooseColorButton.BackColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBackground));

            chooseColorButton.FlatAppearance.BorderColor = Color.FromArgb(
                apiInterface.Setting_GetSkinElementColour(
                    Plugin.SkinElement.SkinInputControl,
                    Plugin.ElementState.ElementStateDefault,
                    Plugin.ElementComponent.ComponentBorder));

            forumLinkLabel.LinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            forumLinkLabel.ActiveLinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateModified,
                Plugin.ElementComponent.ComponentForeground));

            githubLinkLabel.LinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            githubLinkLabel.ActiveLinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateModified,
                Plugin.ElementComponent.ComponentForeground));

            configLinkLabel.LinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            configLinkLabel.ActiveLinkColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputPanelLabel,
                Plugin.ElementState.ElementStateModified,
                Plugin.ElementComponent.ComponentForeground));

            linkTableLayoutPanel.ForeColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            linkTableLayoutPanel.BackColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBackground));

            extractionListView.ForeColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            extractionListView.BackColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinInputControl,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBackground));

            #endregion
        }

        public void reloadColors(Dictionary<string, IP.Color> colorDict)
        {
            {
                var accentDark3 = colorDict["accent-dark3"];
                darkAccent3Panel.BackColor = Color.FromArgb(accentDark3.R, accentDark3.G, accentDark3.B);
            }

            {
                var accentDark2 = colorDict["accent-dark2"];
                darkAccent2Panel.BackColor = Color.FromArgb(accentDark2.R, accentDark2.G, accentDark2.B);
            }

            {
                var accentDark1 = colorDict["accent-dark1"];
                darkAccent1Panel.BackColor = Color.FromArgb(accentDark1.R, accentDark1.G, accentDark1.B);
            }

            {
                var accentNeutral0 = colorDict["accent"];
                neutralAccent0Panel.BackColor = Color.FromArgb(accentNeutral0.R, accentNeutral0.G, accentNeutral0.B);
            }

            {
                var accentLight1 = colorDict["accent-light1"];
                lightAccent1Panel.BackColor = Color.FromArgb(accentLight1.R, accentLight1.G, accentLight1.B);
            }

            {
                var accentLight2 = colorDict["accent-light2"];
                lightAccent2Panel.BackColor = Color.FromArgb(accentLight2.R, accentLight2.G, accentLight2.B);
            }

            {
                var accentLight3 = colorDict["accent-light3"];
                lightAccent3Panel.BackColor = Color.FromArgb(accentLight3.R, accentLight3.G, accentLight3.B);
            }

            {
                var foreground = colorDict["foreground"];
                foreground0Panel.BackColor = Color.FromArgb(foreground.R, foreground.G, foreground.B);
            }

            {
                var background = colorDict["background"];
                background0Panel.BackColor = Color.FromArgb(background.R, background.G, background.B);
            }
        }

        public void setChosenColor(IP.Color color)
        {
            customColorPanel.BackColor = color.ToSystemColor();
        }

        public void setExtractionItems(List<Tuple<string, string>> pairs)
        {
            extractionListView.Items.Clear();

            foreach (var pair in pairs)
            {
                var item = new ListViewItem();
                item.Text = pair.Item1;
                item.SubItems.Add(pair.Item2);

                extractionListView.Items.Add(item);
            }
        }

        private void listViewColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = extractionListView.Columns[e.ColumnIndex].Width;
        }

        private void listViewDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            var foregroundColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinSubPanel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentForeground));

            var borderColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinSubPanel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBorder));

            var backgroundColor = Color.FromArgb(apiInterface.Setting_GetSkinElementColour(
                Plugin.SkinElement.SkinSubPanel,
                Plugin.ElementState.ElementStateDefault,
                Plugin.ElementComponent.ComponentBackground));

            using (var backgroundBrush = new SolidBrush(backgroundColor))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            using (var borderPen = new Pen(borderColor))
            {
                e.Graphics.DrawRectangle(borderPen, e.Bounds);
            }

            using (var foregroundBrush = new SolidBrush(foregroundColor))
            {
                int yOffset = (e.Bounds.Height - e.Graphics.MeasureString(e.Header.Text, e.Font).ToSize().Height) / 2;
                var newBounds = new Rectangle(e.Bounds.X, e.Bounds.Y + yOffset, e.Bounds.Width,
                    e.Bounds.Height - yOffset);

                e.Graphics.DrawString(e.Header.Text, e.Font, foregroundBrush, newBounds);
            }
        }

        private void listViewDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
    }
}

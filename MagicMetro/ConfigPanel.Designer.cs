using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MusicBeePlugin;

namespace Schlossgeist.MagicMetro
{
    partial class ConfigPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.background0Panel = new System.Windows.Forms.Panel();
            this.foreground0Panel = new System.Windows.Forms.Panel();
            this.lightAccent3Panel = new System.Windows.Forms.Panel();
            this.lightAccent2Panel = new System.Windows.Forms.Panel();
            this.lightAccent1Panel = new System.Windows.Forms.Panel();
            this.neutralAccent0Panel = new System.Windows.Forms.Panel();
            this.darkAccent1Panel = new System.Windows.Forms.Panel();
            this.darkAccent2Panel = new System.Windows.Forms.Panel();
            this.darkAccent3Label = new System.Windows.Forms.Label();
            this.darkAccent3Panel = new System.Windows.Forms.Panel();
            this.availableColorsLabel = new System.Windows.Forms.Label();
            this.darkAccent2Label = new System.Windows.Forms.Label();
            this.darkAccent1Label = new System.Windows.Forms.Label();
            this.neutralAccent0Label = new System.Windows.Forms.Label();
            this.lightAccent1Label = new System.Windows.Forms.Label();
            this.lightAccent2Label = new System.Windows.Forms.Label();
            this.lightAccent3Label = new System.Windows.Forms.Label();
            this.foreground0Label = new System.Windows.Forms.Label();
            this.background0Label = new System.Windows.Forms.Label();
            this.hSeparator0 = new System.Windows.Forms.Label();
            this.rightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.extractControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.extractXMLCLabel = new System.Windows.Forms.Label();
            this.extractImagesButton = new System.Windows.Forms.Button();
            this.extractionListView = new System.Windows.Forms.ListView();
            this.sourceColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.destinationColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.vSeparator0 = new System.Windows.Forms.Label();
            this.customColorLabel = new System.Windows.Forms.Label();
            this.chooseColorControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.customColorPanel = new System.Windows.Forms.Panel();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.linkTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.forumLinkLabel = new System.Windows.Forms.LinkLabel();
            this.configLinkLabel = new System.Windows.Forms.LinkLabel();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.footerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.mainTableLayoutPanel.SuspendLayout();
            this.leftTableLayoutPanel.SuspendLayout();
            this.rightTableLayoutPanel.SuspendLayout();
            this.extractControlsTableLayoutPanel.SuspendLayout();
            this.chooseColorControlsTableLayoutPanel.SuspendLayout();
            this.linkTableLayoutPanel.SuspendLayout();
            this.footerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            this.mainTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTableLayoutPanel.ColumnCount = 3;
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.5F));
            this.mainTableLayoutPanel.Controls.Add(this.leftTableLayoutPanel, 0, 0);
            this.mainTableLayoutPanel.Controls.Add(this.hSeparator0, 1, 0);
            this.mainTableLayoutPanel.Controls.Add(this.rightTableLayoutPanel, 2, 0);
            this.mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            this.mainTableLayoutPanel.RowCount = 1;
            this.mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainTableLayoutPanel.Size = new System.Drawing.Size(675, 210);
            this.mainTableLayoutPanel.TabIndex = 0;
            //
            // leftTableLayoutPanel
            //
            this.leftTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.leftTableLayoutPanel.AutoSize = true;
            this.leftTableLayoutPanel.ColumnCount = 2;
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.leftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.leftTableLayoutPanel.Controls.Add(this.background0Panel, 1, 9);
            this.leftTableLayoutPanel.Controls.Add(this.foreground0Panel, 1, 8);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent3Panel, 1, 7);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent2Panel, 1, 6);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent1Panel, 1, 5);
            this.leftTableLayoutPanel.Controls.Add(this.neutralAccent0Panel, 1, 4);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent1Panel, 1, 3);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent2Panel, 1, 2);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent3Label, 0, 1);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent3Panel, 1, 1);
            this.leftTableLayoutPanel.Controls.Add(this.availableColorsLabel, 0, 0);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent2Label, 0, 2);
            this.leftTableLayoutPanel.Controls.Add(this.darkAccent1Label, 0, 3);
            this.leftTableLayoutPanel.Controls.Add(this.neutralAccent0Label, 0, 4);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent1Label, 0, 5);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent2Label, 0, 6);
            this.leftTableLayoutPanel.Controls.Add(this.lightAccent3Label, 0, 7);
            this.leftTableLayoutPanel.Controls.Add(this.foreground0Label, 0, 8);
            this.leftTableLayoutPanel.Controls.Add(this.background0Label, 0, 9);
            this.leftTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.leftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftTableLayoutPanel.Name = "leftTableLayoutPanel";
            this.leftTableLayoutPanel.RowCount = 11;
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.leftTableLayoutPanel.Size = new System.Drawing.Size(334, 210);
            this.leftTableLayoutPanel.TabIndex = 0;
            //
            // background0Panel
            //
            this.background0Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.background0Panel.Location = new System.Drawing.Point(315, 183);
            this.background0Panel.Name = "background0Panel";
            this.background0Panel.Size = new System.Drawing.Size(16, 14);
            this.background0Panel.TabIndex = 9;
            //
            // foreground0Panel
            //
            this.foreground0Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.foreground0Panel.Location = new System.Drawing.Point(315, 163);
            this.foreground0Panel.Name = "foreground0Panel";
            this.foreground0Panel.Size = new System.Drawing.Size(16, 14);
            this.foreground0Panel.TabIndex = 8;
            //
            // lightAccent3Panel
            //
            this.lightAccent3Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent3Panel.Location = new System.Drawing.Point(315, 143);
            this.lightAccent3Panel.Name = "lightAccent3Panel";
            this.lightAccent3Panel.Size = new System.Drawing.Size(16, 14);
            this.lightAccent3Panel.TabIndex = 7;
            //
            // lightAccent2Panel
            //
            this.lightAccent2Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent2Panel.Location = new System.Drawing.Point(315, 123);
            this.lightAccent2Panel.Name = "lightAccent2Panel";
            this.lightAccent2Panel.Size = new System.Drawing.Size(16, 14);
            this.lightAccent2Panel.TabIndex = 6;
            //
            // lightAccent1Panel
            //
            this.lightAccent1Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent1Panel.Location = new System.Drawing.Point(315, 103);
            this.lightAccent1Panel.Name = "lightAccent1Panel";
            this.lightAccent1Panel.Size = new System.Drawing.Size(16, 14);
            this.lightAccent1Panel.TabIndex = 5;
            //
            // neutralAccent0Panel
            //
            this.neutralAccent0Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.neutralAccent0Panel.Location = new System.Drawing.Point(315, 83);
            this.neutralAccent0Panel.Name = "neutralAccent0Panel";
            this.neutralAccent0Panel.Size = new System.Drawing.Size(16, 14);
            this.neutralAccent0Panel.TabIndex = 4;
            //
            // darkAccent1Panel
            //
            this.darkAccent1Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent1Panel.Location = new System.Drawing.Point(315, 63);
            this.darkAccent1Panel.Name = "darkAccent1Panel";
            this.darkAccent1Panel.Size = new System.Drawing.Size(16, 14);
            this.darkAccent1Panel.TabIndex = 3;
            //
            // darkAccent2Panel
            //
            this.darkAccent2Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent2Panel.Location = new System.Drawing.Point(315, 43);
            this.darkAccent2Panel.Name = "darkAccent2Panel";
            this.darkAccent2Panel.Size = new System.Drawing.Size(16, 14);
            this.darkAccent2Panel.TabIndex = 2;
            //
            // darkAccent3Label
            //
            this.darkAccent3Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent3Label.Location = new System.Drawing.Point(3, 23);
            this.darkAccent3Label.Margin = new System.Windows.Forms.Padding(3);
            this.darkAccent3Label.Name = "darkAccent3Label";
            this.darkAccent3Label.Size = new System.Drawing.Size(303, 14);
            this.darkAccent3Label.TabIndex = 0;
            this.darkAccent3Label.Text = "Dark Accent 3";
            this.darkAccent3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // darkAccent3Panel
            //
            this.darkAccent3Panel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent3Panel.Location = new System.Drawing.Point(315, 23);
            this.darkAccent3Panel.Name = "darkAccent3Panel";
            this.darkAccent3Panel.Size = new System.Drawing.Size(16, 14);
            this.darkAccent3Panel.TabIndex = 1;
            //
            // availableColorsLabel
            //
            this.availableColorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.availableColorsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.availableColorsLabel.Location = new System.Drawing.Point(3, 3);
            this.availableColorsLabel.Margin = new System.Windows.Forms.Padding(3);
            this.availableColorsLabel.Name = "availableColorsLabel";
            this.availableColorsLabel.Size = new System.Drawing.Size(303, 14);
            this.availableColorsLabel.TabIndex = 3;
            this.availableColorsLabel.Text = "Available Windows Accent Colors";
            this.availableColorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // darkAccent2Label
            //
            this.darkAccent2Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent2Label.Location = new System.Drawing.Point(3, 43);
            this.darkAccent2Label.Margin = new System.Windows.Forms.Padding(3);
            this.darkAccent2Label.Name = "darkAccent2Label";
            this.darkAccent2Label.Size = new System.Drawing.Size(303, 14);
            this.darkAccent2Label.TabIndex = 4;
            this.darkAccent2Label.Text = "Dark Accent 2";
            this.darkAccent2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // darkAccent1Label
            //
            this.darkAccent1Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.darkAccent1Label.Location = new System.Drawing.Point(3, 63);
            this.darkAccent1Label.Margin = new System.Windows.Forms.Padding(3);
            this.darkAccent1Label.Name = "darkAccent1Label";
            this.darkAccent1Label.Size = new System.Drawing.Size(303, 14);
            this.darkAccent1Label.TabIndex = 5;
            this.darkAccent1Label.Text = "Dark Accent 1";
            this.darkAccent1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // neutralAccent0Label
            //
            this.neutralAccent0Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.neutralAccent0Label.Location = new System.Drawing.Point(3, 83);
            this.neutralAccent0Label.Margin = new System.Windows.Forms.Padding(3);
            this.neutralAccent0Label.Name = "neutralAccent0Label";
            this.neutralAccent0Label.Size = new System.Drawing.Size(303, 14);
            this.neutralAccent0Label.TabIndex = 6;
            this.neutralAccent0Label.Text = "Neutral Accent";
            this.neutralAccent0Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lightAccent1Label
            //
            this.lightAccent1Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent1Label.Location = new System.Drawing.Point(3, 103);
            this.lightAccent1Label.Margin = new System.Windows.Forms.Padding(3);
            this.lightAccent1Label.Name = "lightAccent1Label";
            this.lightAccent1Label.Size = new System.Drawing.Size(303, 14);
            this.lightAccent1Label.TabIndex = 7;
            this.lightAccent1Label.Text = "Light Accent 1";
            this.lightAccent1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lightAccent2Label
            //
            this.lightAccent2Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent2Label.Location = new System.Drawing.Point(3, 123);
            this.lightAccent2Label.Margin = new System.Windows.Forms.Padding(3);
            this.lightAccent2Label.Name = "lightAccent2Label";
            this.lightAccent2Label.Size = new System.Drawing.Size(303, 14);
            this.lightAccent2Label.TabIndex = 8;
            this.lightAccent2Label.Text = "Light Accent 2";
            this.lightAccent2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lightAccent3Label
            //
            this.lightAccent3Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.lightAccent3Label.Location = new System.Drawing.Point(3, 143);
            this.lightAccent3Label.Margin = new System.Windows.Forms.Padding(3);
            this.lightAccent3Label.Name = "lightAccent3Label";
            this.lightAccent3Label.Size = new System.Drawing.Size(303, 14);
            this.lightAccent3Label.TabIndex = 9;
            this.lightAccent3Label.Text = "Light Accent 3";
            this.lightAccent3Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // foreground0Label
            //
            this.foreground0Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.foreground0Label.Location = new System.Drawing.Point(3, 163);
            this.foreground0Label.Margin = new System.Windows.Forms.Padding(3);
            this.foreground0Label.Name = "foreground0Label";
            this.foreground0Label.Size = new System.Drawing.Size(303, 14);
            this.foreground0Label.TabIndex = 10;
            this.foreground0Label.Text = "Foreground";
            this.foreground0Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // background0Label
            //
            this.background0Label.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.background0Label.Location = new System.Drawing.Point(3, 183);
            this.background0Label.Margin = new System.Windows.Forms.Padding(3);
            this.background0Label.Name = "background0Label";
            this.background0Label.Size = new System.Drawing.Size(303, 14);
            this.background0Label.TabIndex = 11;
            this.background0Label.Text = "Background";
            this.background0Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // hSeparator0
            //
            this.hSeparator0.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.hSeparator0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hSeparator0.Location = new System.Drawing.Point(336, 1);
            this.hSeparator0.Margin = new System.Windows.Forms.Padding(1);
            this.hSeparator0.Name = "hSeparator0";
            this.hSeparator0.Size = new System.Drawing.Size(1, 208);
            this.hSeparator0.TabIndex = 2;
            this.hSeparator0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // rightTableLayoutPanel
            //
            this.rightTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.rightTableLayoutPanel.ColumnCount = 1;
            this.rightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTableLayoutPanel.Controls.Add(this.extractControlsTableLayoutPanel, 0, 0);
            this.rightTableLayoutPanel.Controls.Add(this.extractionListView, 0, 1);
            this.rightTableLayoutPanel.Controls.Add(this.vSeparator0, 0, 2);
            this.rightTableLayoutPanel.Controls.Add(this.customColorLabel, 0, 3);
            this.rightTableLayoutPanel.Controls.Add(this.chooseColorControlsTableLayoutPanel, 0, 4);
            this.rightTableLayoutPanel.Location = new System.Drawing.Point(340, 0);
            this.rightTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightTableLayoutPanel.Name = "rightTableLayoutPanel";
            this.rightTableLayoutPanel.RowCount = 6;
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.rightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.rightTableLayoutPanel.Size = new System.Drawing.Size(335, 210);
            this.rightTableLayoutPanel.TabIndex = 1;
            //
            // extractControlsTableLayoutPanel
            //
            this.extractControlsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.extractControlsTableLayoutPanel.ColumnCount = 2;
            this.extractControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.extractControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.extractControlsTableLayoutPanel.Controls.Add(this.extractXMLCLabel, 0, 0);
            this.extractControlsTableLayoutPanel.Controls.Add(this.extractImagesButton, 1, 0);
            this.extractControlsTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.extractControlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.extractControlsTableLayoutPanel.Name = "extractControlsTableLayoutPanel";
            this.extractControlsTableLayoutPanel.RowCount = 1;
            this.extractControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.extractControlsTableLayoutPanel.Size = new System.Drawing.Size(335, 25);
            this.extractControlsTableLayoutPanel.TabIndex = 1;
            //
            // extractXMLCLabel
            //
            this.extractXMLCLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.extractXMLCLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.extractXMLCLabel.Location = new System.Drawing.Point(3, 3);
            this.extractXMLCLabel.Margin = new System.Windows.Forms.Padding(3);
            this.extractXMLCLabel.Name = "extractXMLCLabel";
            this.extractXMLCLabel.Size = new System.Drawing.Size(245, 19);
            this.extractXMLCLabel.TabIndex = 0;
            this.extractXMLCLabel.Text = "Extraction Settings";
            this.extractXMLCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // extractImagesButton
            //
            this.extractImagesButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.extractImagesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.extractImagesButton.Location = new System.Drawing.Point(254, 1);
            this.extractImagesButton.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.extractImagesButton.Name = "extractImagesButton";
            this.extractImagesButton.Size = new System.Drawing.Size(78, 23);
            this.extractImagesButton.TabIndex = 0;
            this.extractImagesButton.Text = "Extract";
            this.extractImagesButton.UseVisualStyleBackColor = true;
            //
            // extractionListView
            //
            this.extractionListView.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.extractionListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.extractionListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.sourceColumnHeader, this.destinationColumnHeader});
            this.extractionListView.FullRowSelect = true;
            this.extractionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.extractionListView.LabelWrap = false;
            this.extractionListView.Location = new System.Drawing.Point(3, 28);
            this.extractionListView.MultiSelect = false;
            this.extractionListView.Name = "extractionListView";
            this.extractionListView.OwnerDraw = true;
            this.extractionListView.ShowItemToolTips = true;
            this.extractionListView.Size = new System.Drawing.Size(329, 107);
            this.extractionListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.extractionListView.TabIndex = 2;
            this.extractionListView.UseCompatibleStateImageBehavior = false;
            this.extractionListView.View = System.Windows.Forms.View.Details;
            this.extractionListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listViewColumnWidthChanging);
            this.extractionListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listViewDrawColumnHeader);
            this.extractionListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listViewDrawItem);
            //
            // sourceColumnHeader
            //
            this.sourceColumnHeader.Text = "Source";
            this.sourceColumnHeader.Width = 160;
            //
            // destinationColumnHeader
            //
            this.destinationColumnHeader.Text = "Destination";
            this.destinationColumnHeader.Width = 160;
            //
            // vSeparator0
            //
            this.vSeparator0.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.vSeparator0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vSeparator0.Location = new System.Drawing.Point(3, 138);
            this.vSeparator0.Name = "vSeparator0";
            this.vSeparator0.Size = new System.Drawing.Size(329, 1);
            this.vSeparator0.TabIndex = 5;
            this.vSeparator0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // customColorLabel
            //
            this.customColorLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.customColorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.customColorLabel.Location = new System.Drawing.Point(3, 142);
            this.customColorLabel.Margin = new System.Windows.Forms.Padding(3);
            this.customColorLabel.Name = "customColorLabel";
            this.customColorLabel.Size = new System.Drawing.Size(329, 19);
            this.customColorLabel.TabIndex = 7;
            this.customColorLabel.Text = "Custom Color";
            this.customColorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // chooseColorControlsTableLayoutPanel
            //
            this.chooseColorControlsTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseColorControlsTableLayoutPanel.ColumnCount = 2;
            this.chooseColorControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.06944F));
            this.chooseColorControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 89.93056F));
            this.chooseColorControlsTableLayoutPanel.Controls.Add(this.customColorPanel, 0, 0);
            this.chooseColorControlsTableLayoutPanel.Controls.Add(this.chooseColorButton, 1, 0);
            this.chooseColorControlsTableLayoutPanel.Location = new System.Drawing.Point(3, 167);
            this.chooseColorControlsTableLayoutPanel.Name = "chooseColorControlsTableLayoutPanel";
            this.chooseColorControlsTableLayoutPanel.RowCount = 1;
            this.chooseColorControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.chooseColorControlsTableLayoutPanel.Size = new System.Drawing.Size(329, 31);
            this.chooseColorControlsTableLayoutPanel.TabIndex = 8;
            //
            // customColorPanel
            //
            this.customColorPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.customColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customColorPanel.Location = new System.Drawing.Point(3, 3);
            this.customColorPanel.Name = "customColorPanel";
            this.customColorPanel.Size = new System.Drawing.Size(27, 25);
            this.customColorPanel.TabIndex = 10;
            //
            // chooseColorButton
            //
            this.chooseColorButton.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseColorButton.Location = new System.Drawing.Point(36, 3);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(290, 25);
            this.chooseColorButton.TabIndex = 7;
            this.chooseColorButton.Text = "Choose";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            //
            // linkTableLayoutPanel
            //
            this.linkTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.linkTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.linkTableLayoutPanel.ColumnCount = 4;
            this.linkTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.linkTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.linkTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.linkTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.linkTableLayoutPanel.Controls.Add(this.githubLinkLabel, 0, 0);
            this.linkTableLayoutPanel.Controls.Add(this.forumLinkLabel, 1, 0);
            this.linkTableLayoutPanel.Controls.Add(this.configLinkLabel, 2, 0);
            this.linkTableLayoutPanel.Controls.Add(this.copyrightLabel, 3, 0);
            this.linkTableLayoutPanel.Location = new System.Drawing.Point(0, 210);
            this.linkTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.linkTableLayoutPanel.Name = "linkTableLayoutPanel";
            this.linkTableLayoutPanel.RowCount = 1;
            this.linkTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.linkTableLayoutPanel.Size = new System.Drawing.Size(675, 25);
            this.linkTableLayoutPanel.TabIndex = 4;
            //
            // githubLinkLabel
            //
            this.githubLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.githubLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.githubLinkLabel.Location = new System.Drawing.Point(4, 4);
            this.githubLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(161, 17);
            this.githubLinkLabel.TabIndex = 2;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "Github";
            this.githubLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // forumLinkLabel
            //
            this.forumLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.forumLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.forumLinkLabel.Location = new System.Drawing.Point(172, 4);
            this.forumLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.forumLinkLabel.Name = "forumLinkLabel";
            this.forumLinkLabel.Size = new System.Drawing.Size(161, 17);
            this.forumLinkLabel.TabIndex = 0;
            this.forumLinkLabel.TabStop = true;
            this.forumLinkLabel.Text = "Forum";
            this.forumLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // configLinkLabel
            //
            this.configLinkLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.configLinkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.configLinkLabel.Location = new System.Drawing.Point(340, 4);
            this.configLinkLabel.Margin = new System.Windows.Forms.Padding(3);
            this.configLinkLabel.Name = "configLinkLabel";
            this.configLinkLabel.Size = new System.Drawing.Size(161, 17);
            this.configLinkLabel.TabIndex = 1;
            this.configLinkLabel.TabStop = true;
            this.configLinkLabel.Text = "Config File";
            this.configLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // copyrightLabel
            //
            this.copyrightLabel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.copyrightLabel.Location = new System.Drawing.Point(508, 4);
            this.copyrightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(163, 17);
            this.copyrightLabel.TabIndex = 3;
            this.copyrightLabel.Text = "© Schlossgeist";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // colorDialog
            //
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            //
            // footerTableLayoutPanel
            //
            this.footerTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.footerTableLayoutPanel.ColumnCount = 1;
            this.footerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.footerTableLayoutPanel.Controls.Add(this.linkTableLayoutPanel, 0, 1);
            this.footerTableLayoutPanel.Controls.Add(this.mainTableLayoutPanel, 0, 0);
            this.footerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.footerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.footerTableLayoutPanel.Name = "footerTableLayoutPanel";
            this.footerTableLayoutPanel.RowCount = 2;
            this.footerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 210F));
            this.footerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.footerTableLayoutPanel.Size = new System.Drawing.Size(675, 318);
            this.footerTableLayoutPanel.TabIndex = 1;
            // 
            // ConfigPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.footerTableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ConfigPanel";
            this.Size = new System.Drawing.Size(675, 368);
            this.mainTableLayoutPanel.ResumeLayout(false);
            this.mainTableLayoutPanel.PerformLayout();
            this.leftTableLayoutPanel.ResumeLayout(false);
            this.rightTableLayoutPanel.ResumeLayout(false);
            this.extractControlsTableLayoutPanel.ResumeLayout(false);
            this.chooseColorControlsTableLayoutPanel.ResumeLayout(false);
            this.linkTableLayoutPanel.ResumeLayout(false);
            this.footerTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ColumnHeader sourceColumnHeader;
        private System.Windows.Forms.ColumnHeader destinationColumnHeader;

        private System.Windows.Forms.ListView extractionListView;

        private System.Windows.Forms.TableLayoutPanel footerTableLayoutPanel;

        private System.Windows.Forms.LinkLabel githubLinkLabel;

        private System.Windows.Forms.LinkLabel forumLinkLabel;
        private System.Windows.Forms.LinkLabel configLinkLabel;

        private System.Windows.Forms.TableLayoutPanel linkTableLayoutPanel;

        private System.Windows.Forms.Label copyrightLabel;

        private System.Windows.Forms.Panel customColorPanel;

        private System.Windows.Forms.TableLayoutPanel chooseColorControlsTableLayoutPanel;

        private System.Windows.Forms.Button chooseColorButton;

        private System.Windows.Forms.Label customColorLabel;

        private System.Windows.Forms.Label hSeparator0;

        private System.Windows.Forms.Label vSeparator0;

        private System.Windows.Forms.ColorDialog colorDialog;

        private System.Windows.Forms.Button extractImagesButton;

        private System.Windows.Forms.TableLayoutPanel extractControlsTableLayoutPanel;

        private System.Windows.Forms.TableLayoutPanel rightTableLayoutPanel;
        private System.Windows.Forms.Label extractXMLCLabel;

        private System.Windows.Forms.Label background0Label;
        private System.Windows.Forms.Panel background0Panel;

        private System.Windows.Forms.Label lightAccent1Label;
        private System.Windows.Forms.Panel lightAccent1Panel;
        private System.Windows.Forms.Label lightAccent2Label;
        private System.Windows.Forms.Panel lightAccent2Panel;
        private System.Windows.Forms.Label lightAccent3Label;
        private System.Windows.Forms.Panel lightAccent3Panel;
        private System.Windows.Forms.Label foreground0Label;
        private System.Windows.Forms.Panel foreground0Panel;

        private System.Windows.Forms.Label darkAccent1Label;
        private System.Windows.Forms.Panel darkAccent1Panel;
        private System.Windows.Forms.Label neutralAccent0Label;
        private System.Windows.Forms.Panel neutralAccent0Panel;

        private System.Windows.Forms.Label darkAccent2Label;
        private System.Windows.Forms.Panel darkAccent2Panel;

        private System.Windows.Forms.Label availableColorsLabel;

        private System.Windows.Forms.Label darkAccent3Label;
        private System.Windows.Forms.Panel darkAccent3Panel;

        private System.Windows.Forms.TableLayoutPanel leftTableLayoutPanel;

        private System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;

        #endregion
    }
}

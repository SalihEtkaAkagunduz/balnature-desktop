namespace BAL_Nature
{
    partial class Form13
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.radRichTextEditor1 = new Telerik.WinControls.UI.RadRichTextEditor();
            this.panel2 = new System.Windows.Forms.Panel();
            this.windows11Theme1 = new Telerik.WinControls.Themes.Windows11Theme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextEditorRibbonBar2 = new Telerik.WinControls.UI.RichTextEditorRibbonBar();
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).BeginInit();
            this.radRichTextEditor1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // radRichTextEditor1
            // 
            this.radRichTextEditor1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(189)))), ((int)(((byte)(232)))));
            this.radRichTextEditor1.Controls.Add(this.panel2);
            this.radRichTextEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radRichTextEditor1.Location = new System.Drawing.Point(0, 0);
            this.radRichTextEditor1.Name = "radRichTextEditor1";
            this.radRichTextEditor1.SelectionFill = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(78)))), ((int)(((byte)(158)))), ((int)(((byte)(255)))));
            this.radRichTextEditor1.SelectionStroke = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(236)))), ((int)(((byte)(248)))));
            this.radRichTextEditor1.Size = new System.Drawing.Size(1414, 743);
            this.radRichTextEditor1.TabIndex = 0;
            this.radRichTextEditor1.ProviderUILayerInitialized += new System.EventHandler<Telerik.WinControls.UI.ProviderUILayerInitilizedEventArgs>(this.radRichTextEditor1_ProviderUILayerInitialized);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(489, 698);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1344, 227);
            this.panel2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radRichTextEditor1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1414, 743);
            this.panel1.TabIndex = 2;
            // 
            // richTextEditorRibbonBar2
            // 
            this.richTextEditorRibbonBar2.ApplicationMenuStyle = Telerik.WinControls.UI.ApplicationMenuStyle.BackstageView;
            this.richTextEditorRibbonBar2.AssociatedRichTextEditor = this.radRichTextEditor1;
            this.richTextEditorRibbonBar2.BuiltInStylesVersion = Telerik.WinForms.Documents.Model.Styles.BuiltInStylesVersion.Office2013;
            this.richTextEditorRibbonBar2.EnableKeyMap = false;
            this.richTextEditorRibbonBar2.Location = new System.Drawing.Point(0, 0);
            this.richTextEditorRibbonBar2.Name = "richTextEditorRibbonBar2";
            this.richTextEditorRibbonBar2.ShowLayoutModeButton = true;
            this.richTextEditorRibbonBar2.Size = new System.Drawing.Size(1414, 225);
            this.richTextEditorRibbonBar2.TabIndex = 0;
            this.richTextEditorRibbonBar2.TabStop = false;
            this.richTextEditorRibbonBar2.Text = "Form1";
            this.richTextEditorRibbonBar2.ThemeName = "Windows11";
            this.richTextEditorRibbonBar2.Click += new System.EventHandler(this.richTextEditorRibbonBar2_Click);
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 968);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextEditorRibbonBar2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form13";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radRichTextEditor1)).EndInit();
            this.radRichTextEditor1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.richTextEditorRibbonBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadRichTextEditor radRichTextEditor1;
        private Telerik.WinControls.Themes.Windows11Theme windows11Theme1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RichTextEditorRibbonBar richTextEditorRibbonBar2;
    }
}


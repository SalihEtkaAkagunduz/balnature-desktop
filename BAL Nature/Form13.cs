using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.RichTextEditor.UI;
using Telerik.WinControls;
using System.IO;
using Telerik.WinForms.Documents.FormatProviders.OpenXml.Docx;
using Telerik.WinForms.Documents.FormatProviders;
using Telerik.WinForms.Documents.UI.Mentions;

namespace BAL_Nature
{
    public partial class Form13 : Form
    {
        public Form13(string a)
        {
            InitializeComponent(); this.LoadFile("overview.docx");
            this.LoadMentions();

            this.radRichTextEditor1.ProviderUILayerInitialized += radRichTextEditor1_ProviderUILayerInitialized;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radRichTextEditor1_ProviderUILayerInitialized(object sender, Telerik.WinControls.UI.ProviderUILayerInitilizedEventArgs e)
        {
            if (e.Layer.Name == "PagesLayer")
            {
                foreach (Telerik.WinControls.RichTextEditor.UI.UIElement element in e.Container.Children)
                {
                    element.BackColor = Colors.White;
                }

                List<RadElement> headerFooters = this.radRichTextEditor1.RichTextBoxElement.GetDescendants(delegate (RadElement x) { return x is HeaderFooterContainer; }, TreeTraversalMode.BreadthFirst);
                foreach (HeaderFooterContainer container in headerFooters)
                {
                    container.OverlayColor = System.Drawing.Color.FromArgb(128, 255, 255, 255);
                }
            }
        }
        private void LoadFile(string file)
        {
             

            DocumentFormatProviderBase provider = new DocxFormatProvider();

            using (Stream stream = typeof(Form13).Assembly.GetManifestResourceStream("RichTextEditor.SampleDocuments." + file))
            {
                //this.radRichTextEditor1.Document = provider.Import(stream);
            }
        }
        private void LoadMentions()
        {
            List<PersonMentionItem> personMentionItems = new List<PersonMentionItem>()
            {
                new PersonMentionItem() { Name = "Maria Anders", Mail = "mailto:manders@somecompany.com"},

                new PersonMentionItem() { Name = "Antonio Taquería", Mail = "mailto:ataqueria@somecompany.com"},

                new PersonMentionItem() { Name = "Thomas Hardy", Mail = "mailto:thardy@somecompany.com"},

                new PersonMentionItem() { Name = "Anabela Domingues", Mail = "mailto:adomingues@somecompany.com"},

                new PersonMentionItem() { Name = "Peter Quinn", Mail = "mailto:pquin@somecompany.com"}
            };

            PopulateImageOfMentionItems(personMentionItems);

            PersonMentionProvider personProvider = new PersonMentionProvider();
            personProvider.ItemsSource = personMentionItems;

            this.radRichTextEditor1.MentionContext.Providers.Add(personProvider);
        }
        private static void PopulateImageOfMentionItems(List<PersonMentionItem> persons)
        {
            NameToInitialsImageSourceGenerator generator = new NameToInitialsImageSourceGenerator();
            foreach (PersonMentionItem person in persons)
            {
                person.Image = generator.Generate(person.Name);
            }
        }

        private void radRichTextEditorRuler1_Click(object sender, EventArgs e)
        {

        }

        private void richTextEditorRibbonBar2_Click(object sender, EventArgs e)
        {

        }
    }
}

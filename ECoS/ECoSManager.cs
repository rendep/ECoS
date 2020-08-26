using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;

namespace ECoS
{
    public class ECoSManager
    {
        public static string ecosDocumentationURL = "https://docs.google.com/document/d/1LZX99xMwQ59xjePRQV2uP2sc83LfLOiJkZ-eEFUg20o/edit#";

        public static string customizationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\UW\\SEAL\\ECoS";
        public static string customizationFileName = "customization.xml";
        public static string customizationPath = System.IO.Path.Combine(customizationDirectory, customizationFileName);

        public static GeneralCategory[] generalCategories = { GeneralCategory.Efficiency, GeneralCategory.Content, GeneralCategory.Style, GeneralCategory.Others };
        public static SpecificCategory[] specificCategories = { SpecificCategory.Heading, SpecificCategory.Figure, SpecificCategory.Table, SpecificCategory.Equation, SpecificCategory.Reference, SpecificCategory.AutoText, SpecificCategory.Paragraph, SpecificCategory.Sentence, SpecificCategory.Word, SpecificCategory.Title, SpecificCategory.Abstract, SpecificCategory.Introduction, SpecificCategory.Background, SpecificCategory.ProposedTasks, SpecificCategory.Timeline, SpecificCategory.BiographicalSketches, SpecificCategory.DocumentOrganization, SpecificCategory.Proposals, SpecificCategory.ResearchPapers, SpecificCategory.GraduateThesis, SpecificCategory.BusinessPlans, SpecificCategory.Others };

        IList<CommentNode> commentNodes = new List<CommentNode>();
        //HashSet<CommentNode> commentNodes = new HashSet<CommentNode>();
        IList<CustomComment> customComments = new List<CustomComment>();

        Dictionary<GeneralCategory, string> generalCategoryDisplayNames = new Dictionary<GeneralCategory, string>();
        Dictionary<SpecificCategory, string> specificCategoryDisplayNames = new Dictionary<SpecificCategory, string>();
        Dictionary<string, string> tagValueList = new Dictionary<string, string>();

        public ECoSManager()
        {
            this.initializeDisplayNames();
            this.initializeFile(customizationDirectory);
            this.readCustomFile();
            //this.readCommentFile();
            this.initializeCommentNodes();
        }      
        
        public void initializeCommentNodes()
        {
            var currentDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            currentDirectory = currentDirectory.Substring(6);        
            DirectoryInfo currentDirectoryInfo = new DirectoryInfo(currentDirectory);
            String grandParentPath = currentDirectoryInfo.Parent.Parent.FullName;
            XElement root = XElement.Load(Path.Combine(grandParentPath, "Ribbon.xml"));
            XNamespace aw = "http://schemas.microsoft.com/office/2009/07/customui";
            IEnumerable<XElement> result = root.Descendants(aw + "group");
            foreach (XElement comment in result.Descendants(aw + "button"))
            {
                if ((string)comment.Attribute("tag") != null)
                {
                    String[] tag = ((string)comment.Attribute("tag")).Split(':');
                    String newComment = tag[0];
                    String specific = tag[1];
                    String general = tag[2];
                    tagValueList[newComment] = specific + ":" + general;
                }
            }
        }
        // Basic Functions

        public void AddComment(String comment, Object oAddress = null, Object oSubAddress = null, GeneralCategory generalCategory = GeneralCategory.Others, SpecificCategory specificCategory = SpecificCategory.Others)
        {
            Word.Selection selection = Globals.ThisAddIn.Application.Selection;
            Word.Range range = selection.Range;
            Word.Comment currentComment = null;
            try
            {
                currentComment = Globals.ThisAddIn.Application.ActiveDocument.Comments.Add(range, comment);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                return;
            }
            if (oAddress != null && oAddress is string && (oAddress as string).Length > 1)
            {
                Object oMissing = null;
                Object oTextToDisplay = comment + "\r\rCtrl + Click to learn more.";
                currentComment.Range.Hyperlinks.Add(currentComment.Range, ref oAddress, ref oSubAddress, ref oMissing, ref oTextToDisplay, ref oMissing);
            }
            //string selectedText = selection.Text.Replace("\r", " ");
            //this.commentNodes.Add(new CommentNode(generalCategory, specificCategory, selectedText));
            //this.commentNodes.Add(new CommentNode(generalCategory, specificCategory, selection.Text));
        }

        public void initializeFile(String directory)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
        }
        /*
        public void readCommentFile()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load("Resources/RibbonLayout.xml");//unsure if this is correct url
                XmlNodeList List = document.SelectNodes("ribbon");//probably doesn't work
                foreach (XmlNode comment in List)//this is definitely wrong, probably will require nested loop
                {
                    string title = customization.SelectSingleNode("title").InnerText;
                    string comment = customization.SelectSingleNode("comment").InnerText;
                    string referenceURL = customization.SelectSingleNode("reference").InnerText;
                    CustomComment newComment = new CustomComment(title, comment, referenceURL);
                    this.customComments.Add(newComment);
                }
            }
            catch (Exception e) { }
        }
        */
        /*
        public CommentNode GetComment(int index)
        {
            if (index >= 0 && index < this.commentNodes.Count)
            {
                return this.commentNodes[index];
            }
            return null;
        }*/

        // Customization

        public void readCustomFile()
        {
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(customizationPath);
                XmlNodeList customizationList = document.SelectNodes("customizations/customization");
                foreach (XmlNode customization in customizationList)
                {
                    string title = customization.SelectSingleNode("title").InnerText;
                    string comment = customization.SelectSingleNode("comment").InnerText;
                    string referenceURL = customization.SelectSingleNode("reference").InnerText;
                    CustomComment newComment = new CustomComment(title, comment, referenceURL);
                    this.customComments.Add(newComment);
                }
            }
            catch (Exception e) { }
        }

        public void saveToFile()
        {
            XmlTextWriter textWriter = new XmlTextWriter(customizationPath, Encoding.UTF8);
            textWriter.WriteStartDocument();
            textWriter.WriteStartElement("customizations");
            foreach (CustomComment customComment in this.customComments)
            {
                textWriter.WriteStartElement("customization");
                textWriter.WriteStartElement("title");
                textWriter.WriteString(customComment.title);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("comment");
                textWriter.WriteString(customComment.comment);
                textWriter.WriteEndElement();
                textWriter.WriteStartElement("reference");
                textWriter.WriteString(customComment.referenceURL);
                textWriter.WriteEndElement();
                textWriter.WriteEndElement();
            }
            textWriter.WriteEndElement();
            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        public int GetCustomCommentCount()
        {
            return this.customComments.Count;
        }

        public CustomComment GetCustomComment(int index)
        {
            if (index >= 0 && index < this.customComments.Count)
            {
                return this.customComments[index];
            }
            return null;
        }

        public void AddCustomComment(CustomComment customComment)
        {
            this.customComments.Add(customComment);
            this.saveToFile();
        }

        public void RemoveCustomComment(int index)
        {
            if (index >= 0 && index < this.customComments.Count)
            {
                this.customComments.RemoveAt(index);
                this.saveToFile();
            }
        }

        public string getNewCustomCommentDefaultTitle()
        {
            string result = "My Comment";
            int counter = 2;
            while (this.customCommentTitlesContain(result))
            {
                result = "My Comment " + counter++;
            }
            return result;
        }

        private bool customCommentTitlesContain(string title)
        {
            foreach (CustomComment customComment in this.customComments)
            {
                if (customComment.title.Equals(title))
                {
                    return true;
                }
            }
            return false;
        }

        // Report Card

        private void initializeDisplayNames()
        {
            this.generalCategoryDisplayNames[GeneralCategory.Efficiency] = "Efficiency";
            this.generalCategoryDisplayNames[GeneralCategory.Content] = "Content";
            this.generalCategoryDisplayNames[GeneralCategory.Style] = "Style";
            this.generalCategoryDisplayNames[GeneralCategory.Others] = "Others";

            this.specificCategoryDisplayNames[SpecificCategory.Heading] = "Heading";
            this.specificCategoryDisplayNames[SpecificCategory.Figure] = "Figure";
            this.specificCategoryDisplayNames[SpecificCategory.Table] = "Table";
            this.specificCategoryDisplayNames[SpecificCategory.Equation] = "Equation";
            this.specificCategoryDisplayNames[SpecificCategory.Reference] = "Reference";
            this.specificCategoryDisplayNames[SpecificCategory.AutoText] = "Auto Text";
            this.specificCategoryDisplayNames[SpecificCategory.Paragraph] = "Paragraph";
            this.specificCategoryDisplayNames[SpecificCategory.Sentence] = "Sentence";
            this.specificCategoryDisplayNames[SpecificCategory.Word] = "Word";
            this.specificCategoryDisplayNames[SpecificCategory.Title] = "Title";
            this.specificCategoryDisplayNames[SpecificCategory.Abstract] = "Abstract";
            this.specificCategoryDisplayNames[SpecificCategory.Introduction] = "Introduction";
            this.specificCategoryDisplayNames[SpecificCategory.Background] = "Background";
            this.specificCategoryDisplayNames[SpecificCategory.ProposedTasks] = "Proposed Tasks";
            this.specificCategoryDisplayNames[SpecificCategory.Timeline] = "Timeline";
            this.specificCategoryDisplayNames[SpecificCategory.BiographicalSketches] = "Biographical Sketches";
            this.specificCategoryDisplayNames[SpecificCategory.DocumentOrganization] = "Document Organization";
            this.specificCategoryDisplayNames[SpecificCategory.Proposals] = "Proposals";
            this.specificCategoryDisplayNames[SpecificCategory.ResearchPapers] = "Research Papers";
            this.specificCategoryDisplayNames[SpecificCategory.GraduateThesis] = "Graduate Thesis";
            this.specificCategoryDisplayNames[SpecificCategory.BusinessPlans] = "Business Plans";
            this.specificCategoryDisplayNames[SpecificCategory.Others] = "Others";
        }

        public string getReportCardContent()
        {
            this.commentNodes.Clear();
            foreach (Word.Comment c in Globals.ThisAddIn.Application.ActiveDocument.Comments)
            {
                String newComment = c.Range.Text;
                GeneralCategory generalCategory = getGeneral("other");
                SpecificCategory specificCategory = getSpecific("other");
                foreach (KeyValuePair<string, string> item in tagValueList)
                {
                    if (c.Range.Text.Contains(item.Key))
                    {
                        String[] tag = item.Value.Split(':');
                        String specific = tag[0];
                        String general = tag[1];
                        generalCategory = getGeneral(general);
                        specificCategory = getSpecific(specific);
                    }                  
                }
                this.commentNodes.Add(new CommentNode(generalCategory, specificCategory, newComment));
            }
            if (this.commentNodes.Count == 0)
            {
                return "No comments in this document.";
            }
            else
            {
                string result = "";

                Dictionary<GeneralCategory, int> generalCategoryCount = new Dictionary<GeneralCategory, int>();
                Dictionary<SpecificCategory, int> specificCategoryCount = new Dictionary<SpecificCategory, int>();

                foreach (GeneralCategory generalCategory in generalCategories)
                {
                    generalCategoryCount[generalCategory] = 0;
                }
                foreach (SpecificCategory specificCategory in specificCategories)
                {
                    specificCategoryCount[specificCategory] = 0;
                }

                foreach (CommentNode commentNode in this.commentNodes)
                {
                    GeneralCategory generalCategory = commentNode.generalCategory;
                    SpecificCategory specificCategory = commentNode.specificCategory;
                    generalCategoryCount[generalCategory]++;
                    specificCategoryCount[specificCategory]++;
                }

                int total = this.commentNodes.Count;

                result += "General\r\n\r\n";
                result += String.Format("{0,10}{1,8}{2,12}\r\n", "Category", "Number", "Percentage");

                foreach (GeneralCategory generalCategory in generalCategories)
                {
                    string category = this.generalCategoryDisplayNames[generalCategory];
                    int number = generalCategoryCount[generalCategory];
                    double percentage = 1.0 * number / total;
                    result += String.Format("{0,10}{1,8}{2,12:P2}\r\n", category, number, percentage);
                }

                result += "\r\n----------\r\n\r\nSpecific\r\n\r\n";
                result += String.Format("{0,21}{1,8}{2,12}\r\n", "Category", "Number", "Percentage");

                foreach (SpecificCategory specificCategory in specificCategories)
                {
                    string category = this.specificCategoryDisplayNames[specificCategory];
                    int number = specificCategoryCount[specificCategory];
                    double percentage = 1.0 * number / total;
                    result += String.Format("{0,21}{1,8}{2,12:P2}\r\n", category, number, percentage);
                }

                result += "\r\n----------\r\n\r\nDetails\r\n\r\n";
                result += String.Format("{0,4}  {1}\r\n", "No.", "Selected Text");

                int index = 0;
                foreach (CommentNode commentNode in this.commentNodes)
                {
                    result += String.Format("{0,4}  {1}\r\n", ++index, commentNode.selectedText);
                }

                result += "\r\n----------\r\n\r\n";
                result += String.Format("{0} comment{1} in total", index, (index > 1 ? "s" : ""));

                return result;
            }
        }

        private GeneralCategory getGeneral(String cat)
        {
            switch (cat)
            {
                case "efficiency":
                    return GeneralCategory.Efficiency;
                case "content":
                    return GeneralCategory.Content;
                case "style":
                    return GeneralCategory.Style;
            }
            return GeneralCategory.Others;
        }

        private SpecificCategory getSpecific(String cat)
        {
            switch (cat)
            {
                case "heading":
                    return SpecificCategory.Heading;
                case "figure":
                    return SpecificCategory.Figure;
                case "table":
                    return SpecificCategory.Table;
                case "equation":
                    return SpecificCategory.Equation;
                case "reference":
                    return SpecificCategory.Reference;
                case "autotext":
                    return SpecificCategory.AutoText;
                case "paragraph":
                    return SpecificCategory.Paragraph;
                case "sentence":
                    return SpecificCategory.Sentence;
                case "word":
                    return SpecificCategory.Word;
                case "title":
                    return SpecificCategory.Title;
                case "abstract":
                    return SpecificCategory.Abstract;
                case "introduction":
                    return SpecificCategory.Introduction;
                case "background":
                    return SpecificCategory.Background;
                case "proposedtasks":
                    return SpecificCategory.ProposedTasks;
                case "timeline":
                    return SpecificCategory.Timeline;
                case "biographicalsketches":
                    return SpecificCategory.BiographicalSketches;
                case "documentorganization":
                    return SpecificCategory.DocumentOrganization;
                case "proposals":
                    return SpecificCategory.Proposals;
                case "researchpapers":
                    return SpecificCategory.ResearchPapers;
                case "graduatethesis":
                    return SpecificCategory.GraduateThesis;
                case "businessplans":
                    return SpecificCategory.BusinessPlans;
            }
            return SpecificCategory.Others;
        }
    }
}

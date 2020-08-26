using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECoS
{
    public enum GeneralCategory { Efficiency, Content, Style, Others };
    public enum SpecificCategory { Heading, Figure, Table, Equation, Reference, AutoText, Paragraph, Sentence, Word, Title, Abstract, Introduction, Background, ProposedTasks, Timeline, BiographicalSketches, DocumentOrganization, Proposals, ResearchPapers, GraduateThesis, BusinessPlans, Others };

    class CommentNode
    {
        public GeneralCategory generalCategory;
        public SpecificCategory specificCategory;
        public string selectedText;

        public CommentNode() : this(GeneralCategory.Others, SpecificCategory.Others, "") { }

        public CommentNode(GeneralCategory generalCategory, SpecificCategory specificCategory, string selectedText)
        {
            this.generalCategory = generalCategory;
            this.specificCategory = specificCategory;
            this.selectedText = selectedText;
        }
    }
}

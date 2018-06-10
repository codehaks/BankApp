using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace BankApp.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    //[HtmlTargetElement("Pagination")]

    public class PaginationTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "nav";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("aria-label", "Page navigation");
            output.Content.SetHtmlContent(AddPageContent());
        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int PageRange { get; set; }

        public string PageTarget { get; set; }

        private string AddPageContent()
        {

            var content = new StringBuilder();
            content.Append(" <ul class='pagination'>");
            content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}/1'>First</a></li>");

            for (int currentPage = 1; currentPage < PageCount+1; currentPage++)
            {
                var active = currentPage == PageNumber ? "active" : "";
                content.Append($"<li class='page-item {active}'><a class='page-link'href='{PageTarget}/{currentPage}'>{currentPage}</a></li>");
            }


            content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}/{PageCount}'>Last</a></li>");
            content.Append(" </ul");
            return content.ToString();
        }
    }
}
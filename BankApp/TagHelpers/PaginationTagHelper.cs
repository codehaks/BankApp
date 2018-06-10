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
            if (PageRange == 0)
            {
                PageRange = 1;
            }

            if (PageCount < PageRange)
            {
                PageRange = PageCount;
            }

            var content = new StringBuilder();
            content.Append(" <ul class='pagination'>");
            content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}/1'>First</a></li>");

            if (PageNumber <= PageRange)
            {
                for (int currentPage = 1; currentPage < 2 * PageRange + 1; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{PageTarget}/{currentPage}'>{currentPage}</a></li>");
                }
            }
            else if (PageNumber > PageRange && PageNumber < PageCount - PageRange)
            {
                for (int currentPage = PageNumber - PageRange; currentPage < PageNumber + PageRange; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{PageTarget}/{currentPage}'>{currentPage}</a></li>");
                }
            }
            else
            {
                for (int currentPage = PageCount - (2 * PageRange); currentPage < PageCount + 1; currentPage++)
                {
                    if (currentPage < 1 || currentPage > PageCount)
                    {
                        continue;
                    }
                    var active = currentPage == PageNumber ? "active" : "";
                    content.Append($"<li class='page-item {active}'><a class='page-link'href='{PageTarget}/{currentPage}'>{currentPage}</a></li>");
                }
            }

            content.Append($"<li class='page-item'><a class='page-link' href='{PageTarget}/{PageCount}'>Last</a></li>");
            content.Append(" </ul");
            return content.ToString();
        }
    }
}
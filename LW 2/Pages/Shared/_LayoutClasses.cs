
namespace LW_2.Pages
{
    class Sections 
    {
        public required string Name { get; set; }
        public required string Id { get; set; }
    }

    class Site
    {
        public required string HtmlName { get; set; }
        public required string SiteName { get; set; }
    }

    class Image
    {
        public required string HtmlName { get; set; }

    }

    class Footer
    {
        public required string Address { get; set; }
        public required string Email { get; set; }
        public required List<Social> Social { get; set; }
        public required string Copyright { get; set; }
    }

    class Social
    {
        public required string Link { get; set; }
        public required string Icon { get; set; }

    }
}

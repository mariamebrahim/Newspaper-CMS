namespace Newspaper_CMS.Models
{
    public class Article
    {
        public int Article_ID { get; set; }
        public string Article_Title { get; set; }
        public string Article_Description { get; set; }
        public string Writer_Name { get; set; }
        public DateTime? Article_PublishDate { get; set; }
        public int? Article_Active { get; set; }
        public string Category_Name { get; set; }
    }
}

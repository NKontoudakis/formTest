namespace FormTest.DataAccess.Models
{
    public class ApplicationForm
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int RadioChoice { get; set; }
        public bool IsConfirmed { get; set; }
        public int SelectDropdown { get; set; }
    }
}

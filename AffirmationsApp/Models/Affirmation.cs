using System.Data.SqlTypes;

namespace AffirmationsApp.Models
{
    public class Affirmation
    {
        public int Id { get; set; }

        public string User { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public Affirmation()
        {

        }
    }
}

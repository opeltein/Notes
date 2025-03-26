using System;

namespace Notes.Models
{
    public class Note
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // 👈 Automatycznie generujemy ID
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now; // 👈 Automatycznie ustawiamy datę
    }
}

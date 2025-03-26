using Notes.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Notes.Services
{
    public interface INoteService
    {
        Task<List<Note>> GetNotes();  // 👈 Dodajemy Task<>
        Task AddNote(Note note);
        Task DeleteNote(Guid id);
    }
}

using System.Linq;
using Notes.Models;
using System.Threading.Tasks;

namespace Notes.Services
{
    public class NoteService : INoteService
    {
        private const string StorageKey = "notes";
        private readonly ILocalStorageService _localStorageService;

        public NoteService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<List<Note>> GetNotes()
        {
            return await _localStorageService.Get<List<Note>>(StorageKey) ?? new List<Note>();
        }

        public async Task AddNote(Note note)
        {
            note.CreatedAt = DateTime.Now; // 👈 Dodajemy datę utworzenia
            var notes = await GetNotes();
            notes.Add(note);
            await _localStorageService.Set(StorageKey, notes);
        }

        public async Task DeleteNote(Guid id)
        {
            var notes = await GetNotes();
            notes = notes.Where(n => n.Id != id).ToList();
            await _localStorageService.Set(StorageKey, notes);
        }
    }
}

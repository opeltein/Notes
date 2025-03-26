using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Controllers
{
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _noteService.GetNotes();
            notes = notes.OrderByDescending(n => n.CreatedAt).ToList();
            return View(notes); // 👈 Przekazujemy listę do widoku
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Note note)
        {
            if (ModelState.IsValid)
            {
                await _noteService.AddNote(note); // Teraz używamy async
                return RedirectToAction("Index");
            }
            return View(note);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _noteService.DeleteNote(id);
            return RedirectToAction("Index");
        }
    }
}

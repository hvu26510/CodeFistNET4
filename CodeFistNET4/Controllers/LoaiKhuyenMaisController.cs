using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CodeFistNET4.Data;
using CodeFistNET4.Models.DataModels;

namespace CodeFistNET4.Controllers
{
    public class LoaiKhuyenMaisController : Controller
    {
        private readonly SKMDbContext _context;

        public LoaiKhuyenMaisController(SKMDbContext context)
        {
            _context = context;
        }

        // GET: LoaiKhuyenMais
        public async Task<IActionResult> Index()
        {
            return View(await _context.loaiKhuyenMais.ToListAsync());
        }

        // GET: LoaiKhuyenMais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhuyenMai = await _context.loaiKhuyenMais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiKhuyenMai == null)
            {
                return NotFound();
            }

            return View(loaiKhuyenMai);
        }

        // GET: LoaiKhuyenMais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoaiKhuyenMais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TenLoaiKM")] LoaiKhuyenMai loaiKhuyenMai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiKhuyenMai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loaiKhuyenMai);
        }

        // GET: LoaiKhuyenMais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhuyenMai = await _context.loaiKhuyenMais.FindAsync(id);
            if (loaiKhuyenMai == null)
            {
                return NotFound();
            }
            return View(loaiKhuyenMai);
        }

        // POST: LoaiKhuyenMais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TenLoaiKM")] LoaiKhuyenMai loaiKhuyenMai)
        {
            if (id != loaiKhuyenMai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiKhuyenMai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiKhuyenMaiExists(loaiKhuyenMai.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(loaiKhuyenMai);
        }

        // GET: LoaiKhuyenMais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiKhuyenMai = await _context.loaiKhuyenMais
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loaiKhuyenMai == null)
            {
                return NotFound();
            }

            return View(loaiKhuyenMai);
        }

        // POST: LoaiKhuyenMais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiKhuyenMai = await _context.loaiKhuyenMais.FindAsync(id);
            if (loaiKhuyenMai != null)
            {
                _context.loaiKhuyenMais.Remove(loaiKhuyenMai);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiKhuyenMaiExists(int id)
        {
            return _context.loaiKhuyenMais.Any(e => e.Id == id);
        }
    }
}

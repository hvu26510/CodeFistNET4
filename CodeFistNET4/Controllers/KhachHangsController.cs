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
    public class KhachHangsController : Controller
    {
        private readonly SKMDbContext _context;

        public KhachHangsController(SKMDbContext context)
        {
            _context = context;
        }

        // GET: KhachHangs
        public async Task<IActionResult> Index()
        {
            var sKMDbContext = _context.khachHang.Include(k => k.LoaiKhachHang);
            return View(await sKMDbContext.ToListAsync());
        }

        // GET: KhachHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.khachHang
                .Include(k => k.LoaiKhachHang)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khachHang == null)
            {
                return NotFound();
            }

            return View(khachHang);
        }

        // GET: KhachHangs/Create
        public IActionResult Create()
        {
            ViewData["LoaiKHID"] = new SelectList(_context.loaiKhachHangs, "Id", "Id");
            return View();
        }

        // POST: KhachHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,PhoneNumber,Email,Address,LoaiKHID")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LoaiKHID"] = new SelectList(_context.loaiKhachHangs, "Id", "Id", khachHang.LoaiKHID);
            return View(khachHang);
        }

        // GET: KhachHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.khachHang.FindAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            ViewData["LoaiKHID"] = new SelectList(_context.loaiKhachHangs, "Id", "Id", khachHang.LoaiKHID);
            return View(khachHang);
        }

        // POST: KhachHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PhoneNumber,Email,Address,LoaiKHID")] KhachHang khachHang)
        {
            if (id != khachHang.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhachHangExists(khachHang.Id))
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
            ViewData["LoaiKHID"] = new SelectList(_context.loaiKhachHangs, "Id", "Id", khachHang.LoaiKHID);
            return View(khachHang);
        }

        // GET: KhachHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khachHang = await _context.khachHang
                .Include(k => k.LoaiKhachHang)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        // POST: KhachHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khachHang = await _context.khachHang.FindAsync(id);
            if (khachHang != null)
            {
                _context.khachHang.Remove(khachHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhachHangExists(int id)
        {
            return _context.khachHang.Any(e => e.Id == id);
        }
    }
}

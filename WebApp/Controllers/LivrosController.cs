﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.WebApp.DatabaseContext;
using Livraria.WebApp.Models;

namespace Livraria.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly LivrariaContext _context;

        public LivrosController(LivrariaContext context)
        {
            _context = context;
        }

        // GET: api/Livros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livros>>> GetLivros()
        {
            return await _context.Livros.ToListAsync();
        }

        // GET: api/Livros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livros>> GetLivros(int id)
        {
            var livros = await _context.Livros.FindAsync(id);

            if (livros == null)
            {
                return NotFound();
            }

            return livros;
        }

        // PUT: api/Livros/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLivros(int id, Livros livros)
        {
            if (id != livros.Id)
            {
                return BadRequest();
            }

            _context.Entry(livros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivrosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Livros
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Livros>> PostLivros(Livros livros)
        {
            _context.Livros.Add(livros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLivros", new { id = livros.Id }, livros);
        }

        // DELETE: api/Livros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Livros>> DeleteLivros(int id)
        {
            var livros = await _context.Livros.FindAsync(id);
            if (livros == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livros);
            await _context.SaveChangesAsync();

            return livros;
        }

        private bool LivrosExists(int id)
        {
            return _context.Livros.Any(e => e.Id == id);
        }
    }
}

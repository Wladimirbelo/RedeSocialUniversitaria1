﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DDDRedeSocialUniversitaria.Domain;
using DDDRedeSocialUniversitaria.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DDDRedeSocialUniversitaria.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _context;

        public UsuarioRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await GetByIdAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public Usuario GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public bool AddUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetAll()
        {
            throw new NotImplementedException();
        }

        public void UpdateUsuario(int id, Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}
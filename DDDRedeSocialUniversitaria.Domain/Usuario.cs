using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRedeSocialUniversitaria.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Curso { get; set; }
        public List<Usuario> Seguidores { get; set; }

        public Usuario()
        {
            Seguidores = new List<Usuario>();
        }

        // Método para seguir outro usuário
        public void Seguir(Usuario usuario)
        {
            if (!Seguidores.Contains(usuario))
            {
                Seguidores.Add(usuario);
            }
        }
    }
}
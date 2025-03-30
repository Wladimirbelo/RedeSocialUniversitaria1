using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRedeSocialUniversitaria.Domain
{
    public class Postagem
    {
        public int Id { get; set; }
        public Usuario Autor { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataHora { get; set; }
        public List<Usuario> Curtidas { get; set; }
        public List<string> Comentarios { get; set; }

        public Postagem()
        {
            Curtidas = new List<Usuario>();
            Comentarios = new List<string>();
        }

        // Método para curtir a postagem
        public void Curtir(Usuario usuario)
        {
            if (!Curtidas.Contains(usuario))
            {
                Curtidas.Add(usuario);
            }
        }

        // Método para adicionar um comentário
        public void AdicionarComentario(string comentario)
        {
            Comentarios.Add(comentario);
        }
    }
}
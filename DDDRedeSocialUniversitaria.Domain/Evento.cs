using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDRedeSocialUniversitaria.Domain
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public string Descricao { get; set; }
        public DateTime DataHora { get; set; }
        public bool ExigeInscricao { get; set; }
        public List<Usuario> Inscritos { get; set; }

        public Evento()
        {
            Inscritos = new List<Usuario>();
        }

        // Método para inscrever um usuário no evento
        public void Inscrever(Usuario usuario)
        {
            if (ExigeInscricao && !Inscritos.Contains(usuario))
            {
                Inscritos.Add(usuario);
            }
        }
    }
}
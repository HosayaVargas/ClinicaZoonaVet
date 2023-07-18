using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class MascotaPaciente
    {
        public int IdPaciente { get; set; }
        public int IdMascota { get; set; }
        public int Folio { get; set; }
        public Mascota Mascota { get; set; }
        public Paciente Paciente { get; set; }

        public MascotaPaciente() { }

        public MascotaPaciente(Mascota _Mascota, Paciente _Paciente, int _IdPaciente, int _IdMascota, int _Folio)
        {
            this.Mascota = _Mascota;
            this.Paciente = _Paciente;
            this.IdPaciente = _IdPaciente;
            this.IdMascota = _IdMascota;
            this.Folio = _Folio;
        }
    }
}

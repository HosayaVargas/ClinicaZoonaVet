using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Mascota
    {
        public int Folio { get; set; }
        public int IdMascota { get; set; }
        public String NombreMascota { get; set; }
        public char Sexo { get; set; }
        public char CodEspecie { get; set; }
        public char SexoMascota { get; set; }
        public int Chip { get; set; }
        public Paciente Paciente { get; set; }
        public MascotaPaciente MascotaPaciente { get; set; }

        public Mascota() { }

        public Mascota( MascotaPaciente _MascotaPaciente, Paciente _Paciente, int _Folio, int _IdMascota, char _Sexo, string _NombreMascota, char _CodEspecie, char _SexoMascota, int _Chip)
        {
            this.Paciente = _Paciente;
            this.Folio = _Folio;
            this.IdMascota = _IdMascota;
            this.Sexo = _Sexo;
            this.NombreMascota = _NombreMascota;
            this.CodEspecie = _CodEspecie;
            this.SexoMascota = _SexoMascota;
            this.Chip = _Chip;
            this.MascotaPaciente = _MascotaPaciente;
   
        }
    }
}

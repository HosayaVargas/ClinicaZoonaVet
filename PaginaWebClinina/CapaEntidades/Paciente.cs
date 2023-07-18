using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public int IdMascota { get; set; }
        public String Nombres { get; set; }
        public String ApPaterno { get; set; }
        public String ApMaterno { get; set; }
        public Mascota Mascota { get; set; }
        public int Edad { get; set; }
        public char Sexo { get; set; }
        public String NroDocumento { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public bool Estado { get; set; }
        public String Imagen { get; set; }

        public int CodEspecie { get; set; }
        public int CodRaza { get; set; }





        public Paciente() { }


        public Paciente(Mascota _Mascota, int _IdPaciente, int _IdMascota,  String _Nombres, String _ApPaterno, String _ApMaterno, int _Edad, char _Sexo
            , String _NroDocumento, String _Direccion, String _Telefono, bool _Estado, String _Imagen, string _NombreMascota, int _CodEspecie, int _CodRaza, char _SexoMascota, int _Chip, int _Folio)
        {
            this.Mascota = _Mascota;
            this.IdPaciente = _IdPaciente;
            this.IdMascota = _IdMascota;
            this.Nombres = _Nombres;
            this.ApPaterno = _ApPaterno;
            this.ApMaterno = _ApMaterno;
            this.Edad = _Edad;
            this.Sexo = _Sexo;
            this.NroDocumento = _NroDocumento;
            this.Direccion = _Direccion;
            this.Imagen = _Imagen;
   
            this.CodEspecie = _CodEspecie;
            this.CodRaza = _CodRaza;
      
        }

    }
}

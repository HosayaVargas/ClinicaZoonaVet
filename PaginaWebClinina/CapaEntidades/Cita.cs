using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cita
    {
        public int IdCita { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public Mascota Mascota { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Observacion { get; set; }
        public char Estado { get; set; }
        public string Hora { get; set; }
        public MascotaPaciente MascotaPaciente { get; set; }
       

        public Cita() : this(0, new MascotaPaciente(), new Medico(), new Mascota(),  new Paciente(), DateTime.Now, "", ' ', "")
        {
        }

        public Cita(int _IdCita, MascotaPaciente _MascotaPaciente, Medico _Medico, Mascota _Mascota,  Paciente _Paciente, DateTime _FechaReserva, string _Observacion
            , char _Estado, string _Hora)
        {
            this.MascotaPaciente = _MascotaPaciente;
            this.IdCita = _IdCita;
            this.Medico = _Medico;
            this.Mascota = _Mascota;
            this.Paciente = _Paciente;
            this.FechaReserva = _FechaReserva;
            this.Observacion = _Observacion;
            this.Estado = _Estado;
            this.Hora = _Hora;

        }
    }
}

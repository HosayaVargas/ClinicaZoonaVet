using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class HistoriaClinica
    {

        public int IdHistoriaClinica { get; set; }
        public List<Diagnostico> LDiagnostico { get; set; }
        public DateTime FechaApertura { get; set; }
        public bool Estado { get; set; }
        public int IdMascota { get; set; }
        


        public HistoriaClinica()
            : this(0, 0, new List<Diagnostico>(), DateTime.Now, false)
        {

        }

        public HistoriaClinica( int _IdHistoriaClinica, int _IdMascota, List<Diagnostico> _ListaDiagnostico, DateTime _FechaApertura, bool _Estado)
        {
            this.IdHistoriaClinica = _IdHistoriaClinica;
            this.IdMascota = _IdMascota;
            this.LDiagnostico = _ListaDiagnostico;
            this.FechaApertura = _FechaApertura;
            this.Estado = _Estado;
        }


    }
}

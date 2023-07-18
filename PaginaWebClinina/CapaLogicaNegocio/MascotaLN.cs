using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class MascotaLN
    {
        #region "PATRON SINGLETON"
        private static MascotaLN objEmpleado = null;
        private MascotaLN() { }
        public static MascotaLN getInstance()
        {
            if (objEmpleado == null)
            {
                objEmpleado = new MascotaLN();
            }
            return objEmpleado;
        }
        #endregion
       

        public bool RegistrarMascota(Mascota objMascota, int idPaciente) 
        {
            try
            {
                return MascotaDAO.getInstance().RegistrarMascota(objMascota, idPaciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Mascota> ListarMascota()
        {
            try
            {
                return MascotaDAO.getInstance().ListarMascota();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Mascota BuscarMascotaFolio(int folio)
        {
            try
            {
                return MascotaDAO.getInstance().BuscarMascotaFolio(folio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Mascota BuscarPacienteIdCita(Int32 Idcita)
        {
            try
            {
                return MascotaDAO.getInstance().BuscarPacienteIdCita(Idcita);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

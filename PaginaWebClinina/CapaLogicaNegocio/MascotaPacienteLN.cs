using CapaAccesoDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class MascotaPacienteLN
    {
        #region "PATRON SINGLETON"
        private static MascotaPacienteLN objEmpleado = null;
        private MascotaPacienteLN() { }
        public static MascotaPacienteLN getInstance()
        {
            if (objEmpleado == null)
            {
                objEmpleado = new MascotaPacienteLN();
            }
            return objEmpleado;
        }
        #endregion

        public MascotaPaciente BuscarMascotaFolio(int folio)
        {
            try
            {
                return MascotaPacienteDAO.getInstance().BuscarMascotaFolio(folio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    
}

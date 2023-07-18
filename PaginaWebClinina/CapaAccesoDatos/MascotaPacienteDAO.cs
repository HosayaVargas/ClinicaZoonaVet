using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class MascotaPacienteDAO
    {
        #region "PATRON SINGLETON"
        private static MascotaPacienteDAO daoEmpleado = null;
        private MascotaPacienteDAO() { }
        public static MascotaPacienteDAO getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new MascotaPacienteDAO();
            }
            return daoEmpleado;
        }
        #endregion

        public MascotaPaciente BuscarMascotaFolio(int folio)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            MascotaPaciente objmascota = new MascotaPaciente();

            try
            {
                conex = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarMascotaFolio", conex);
                cmd.Parameters.AddWithValue("@prmFolio", folio);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objmascota = new MascotaPaciente()
                    {
                        IdMascota = Convert.ToInt32(dr["idMascota"].ToString()),

                        Paciente = new Paciente()
                        {
                            NroDocumento = dr["nroDocumento"].ToString(),
                            Nombres = dr["nombres"].ToString(),
                            ApPaterno = dr["apPaterno"].ToString(),
                            ApMaterno = dr["apMaterno"].ToString(),
                        },
                        Mascota = new Mascota()
                        {
                            NombreMascota = dr["Mascota"].ToString(),
                            SexoMascota = Convert.ToChar(dr["Sexo"].ToString())

                        }


                    };

                }

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objmascota;

        }
    }
    
}

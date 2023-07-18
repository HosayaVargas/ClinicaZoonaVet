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
    public class MascotaDAO
    {
        #region "PATRON SINGLETON"
        private static MascotaDAO daoEmpleado = null;
        private MascotaDAO() { }
        public static MascotaDAO getInstance()
        {
            if (daoEmpleado == null)
            {
                daoEmpleado = new MascotaDAO();
            }
            return daoEmpleado;
        }
        #endregion

        

        public bool RegistrarMascota(Mascota objMascota, int idPaciente) {

           SqlConnection con = null;
           SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmidPaciente", idPaciente);
                cmd.Parameters.AddWithValue("@prmNombreMascota", objMascota.NombreMascota);
                cmd.Parameters.AddWithValue("@prmChip", objMascota.Chip);
                cmd.Parameters.AddWithValue("@prmSexo", objMascota.SexoMascota);
                cmd.Parameters.AddWithValue("@prmCodEspecie", objMascota.CodEspecie);
                con.Open();

                int filas = cmd.ExecuteNonQuery();
               if (filas > 0) response = true;

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public Mascota BuscarMascotaFolio(int folio)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Mascota objmascota = new Mascota();

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
                    objmascota = new Mascota()
                    {
                        NombreMascota = dr["Mascota"].ToString(),
                        SexoMascota = Convert.ToChar(dr["Sexo"].ToString()),
                        Paciente = new Paciente()
                        {
                            NroDocumento = dr["nroDocumento"].ToString(),
                            Nombres = dr["nombres"].ToString(),
                            ApPaterno = dr["apPaterno"].ToString(),
                            ApMaterno = dr["apMaterno"].ToString(),                           
                        },
                        MascotaPaciente = new MascotaPaciente()
                        {
                            IdMascota = Convert.ToInt32(dr["idMascota"].ToString())

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

        public List<Mascota> ListarMascota()
        {
            List<Mascota> Lista = new List<Mascota>();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;

            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spListarMascota", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                dr = cmd.ExecuteReader();
                
                while (dr.Read())
                {
                    Mascota objmascota = new Mascota();
                    // Crear objetos de tipo Paciente
                    Paciente objpaciente = new Paciente();
                    objmascota.Folio = Convert.ToInt32(dr["Folio"].ToString());
                    objmascota.SexoMascota = Convert.ToChar(dr["SexoMascota"].ToString());
                    objmascota.Chip = Convert.ToChar(dr["Chip"].ToString());
                    objmascota.NombreMascota = dr["nombreMascota"].ToString();


                    objpaciente.IdPaciente = Convert.ToInt32(dr["idPaciente"].ToString());
                    objmascota.Paciente = objpaciente;


                    // añadir a la lista de objetos
                    Lista.Add(objmascota);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return Lista;
        }
        public Mascota BuscarPacienteIdCita(Int32 idCita)
        {
            SqlConnection conex = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            Mascota objMascota = null;

            try
            {
                conex = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spBuscarPacienteIdCita", conex);
                cmd.Parameters.AddWithValue("@prmIdCita", idCita);
                cmd.CommandType = CommandType.StoredProcedure;

                conex.Open();
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    objMascota = new Mascota
                    {
                        IdMascota = Convert.ToInt32(dr["idMascota"].ToString()),
                        NombreMascota = dr["nombreMascota"].ToString (),
                        SexoMascota = Convert.ToChar(dr["SexoMascota"].ToString()),
                        
                    };
                }
            }
            catch (Exception ex)
            {
                objMascota = null;
                throw ex;
            }
            finally
            {
                conex.Close();
            }
            return objMascota;
        }


    }

}


using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebClinina
{
    public partial class GestionarMascotas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

        }
        [WebMethod]
        public static Paciente BuscarUsuarioRut(String rut)
        {
            return PacienteLN.getInstance().BuscarUsuarioRut(rut);
        }

        [WebMethod]
        public static List<Mascota> ListarMascota()
        {
            List<Mascota> Lista = null;
            try
            {
                Lista = MascotaLN.getInstance().ListarMascota();
            }
            catch (Exception)
            {
                Lista = new List<Mascota>();
            }
            return Lista;
        }

        [WebMethod]
        public static Mascota BuscarMascotaFolio(int folio)
        {
            return MascotaLN.getInstance().BuscarMascotaFolio(folio);
        }

        private Mascota GetEntity()
        {
            Mascota objMascota = new Mascota();
            objMascota.NombreMascota = txtMascota.Text;
            objMascota.Chip = Convert.ToInt32(txtChip.Text);
            objMascota.SexoMascota = (ddlSexoMascota.SelectedValue == "Hembra") ? 'H' : 'M'; // Masculino , Femenino
            objMascota.CodEspecie = (ddlEspecie.SelectedValue == "Canino") ? 'C' : 'F'; // Canino , Felino
            return objMascota;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro Mascota
            Mascota objMascota = GetEntity();
            // enviar a la capa de logica de negocio

            int idPaciente = Convert.ToInt32(txtIdPaciente.Text);

            bool response = MascotaLN.getInstance().RegistrarMascota(objMascota, idPaciente);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }

            Limpiar();

        }

        private void Limpiar()
        {
            txtNombres.Text = "";
            txtDNI.Text = "";
            txtApellidos.Text = "";
            txtMascota.Text = "";
            txtChip.Text = "";
            ddlSexoMascota.SelectedIndex = 0;
            ddlEspecie.SelectedIndex = 0;

        }

        
    }
}
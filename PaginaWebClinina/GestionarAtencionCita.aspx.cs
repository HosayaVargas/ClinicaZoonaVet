using CapaEntidades;
using CapaLogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PaginaWebClinina
{
    public partial class GestionarAtencionCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Int32 IdCita = Convert.ToInt32(Request.QueryString["idCita"]);

                LlenarDatosPaciente(IdCita);
            }

        }


        private void LlenarDatosPaciente(Int32 Idcita)
        {
            //llenar la informacion
            Mascota objMascota = MascotaLN.getInstance().BuscarPacienteIdCita(Idcita);
            hfIdMascota.Value = objMascota.IdMascota.ToString();
            lblNombres.Text = objMascota.NombreMascota;
            
            lblSexo.Text = (objMascota.SexoMascota == 'H') ? "HEMBRA" : "MACHO";

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Diagnostico objDiagnostico = new Diagnostico();
            objDiagnostico.HistoriaClinica.IdMascota = Convert.ToInt32(hfIdMascota.Value);
            objDiagnostico.Observacion = txtObservaciones.Text;
            objDiagnostico.SDiagnostico = txtDiagnostico.Text;

            bool ok = DiagnosticoLN.getInstance().RegistrarDiagnostico(objDiagnostico);

            if (ok)
            {
                Response.Write("<script>alert('Diagnóstico registrado correctamente.')</script>");
                btnRegistrar.Enabled = false;
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('No se pudo registrar el diagnóstico.')</script>");
            }



        }
    }
}
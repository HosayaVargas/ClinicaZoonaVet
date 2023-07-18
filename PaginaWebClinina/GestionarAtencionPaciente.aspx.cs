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
    public partial class GestionarAtencionPaciente : System.Web.UI.Page
    {
        private static String COMMAND_REGISTER = "Registrar";
        private static String COMMAND_CANCEL = "Cancelar";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFechaAtencion.Text = DateTime.Now.ToShortDateString();
                llenarDataList();
            }

        }

        private void llenarDataList()
        {
            List<Cita> ListaCitas = CitaLN.getInstance().ListarCitas();
            dlAtencionMedica.DataSource = ListaCitas;
            dlAtencionMedica.DataBind();
        }

        protected void dlAtencionMedica_ItemCommand(object source, DataListCommandEventArgs e)
        {
            String IdCita = (e.Item.FindControl("hdIdCita") as HiddenField).Value;

            if (e.CommandName == COMMAND_REGISTER)
            {
                //realizar el registro de la atención
                //Redirección a la página de GestionarAtencionCita.aspx
                bool response = CitaLN.getInstance().ActualizarCita(Convert.ToInt32(IdCita), "A");

                if (response)
                {
                    Response.Redirect("GestionarAtencionCita.aspx?idcita=" + IdCita);
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE REALIZAR LA ATENCIÓN DE LA CITA.')</script>");
                }


            }
            else if (e.CommandName == COMMAND_CANCEL)
            {
                //realizar la cancelación de la reserva de cita
                bool response = CitaLN.getInstance().ActualizarCita(Convert.ToInt32(IdCita), "E");

                if (response)
                {
                  //  recargar la información
                        llenarDataList();
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUEDE ELIMINAR LA CITA.')</script>");
                }
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text != "")
            {
                BaseDeDatos db = new BaseDeDatos();
                if (ddlBuscar.SelectedValue == "Folio")
                {
                    try
                    {
                        int folio = Convert.ToInt32(txtBuscar.Text);
                        List<Cita> ListarPorFiltros = CitaLN.getInstance().ListarPorFiltros(folio, null);
                        dlAtencionMedica.DataSource = ListarPorFiltros;
                        dlAtencionMedica.DataBind();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                
                if (ddlBuscar.SelectedValue=="Rut Propietario")
                {
                    try
                    {
                        String rut = txtBuscar.Text;
                        List<Cita> ListarPorFiltros = CitaLN.getInstance().ListarPorFiltros(null ,rut);
                        dlAtencionMedica.DataSource = ListarPorFiltros;
                        dlAtencionMedica.DataBind();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
            else
            {
                llenarDataList();
            }
        }
    }
}
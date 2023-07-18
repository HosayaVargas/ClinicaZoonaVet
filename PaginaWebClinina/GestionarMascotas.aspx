<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="GestionarMascotas.aspx.cs" Inherits="PaginaWebClinina.GestionarMascotas" ClientIDMode="Static" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/CssPersonalizado/Mascota.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upPanel" runat="server">
        <ContentTemplate>
            <section class="content-header">
                <h1 style="text-align: center">REGISTRO MASCOTAS</h1>
            </section>
            <section class="content">
                <div class="box-header">
                    <h3 style="text-align: left" class="box-title">Buscar Propietario Existente</h3>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <div class="box-body">
                                <div class="form-group">
                                    <label>RUT</label>
                                </div>
                                <div class="input-group">
                                    <asp:TextBox ID="txtDNI" CssClass="form-control" runat="server" MaxLength="8"></asp:TextBox>
                                    <div class="input-group-btn">
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-danger" Text="BUSCAR" />
                                    </div>
                                </div>
                                <br />

                                <div class="form-group">
                                    <label>NOMBRES</label>
                                    <asp:TextBox ID="txtNombres" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>APELLIDOS</label>
                                    <asp:TextBox ID="txtApellidos" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>ID PROPIETARIO</label>
                                    <asp:TextBox ID="txtIdPaciente" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="box box-primary">
                            <br />
                            <div class="box-body">
                                <div class="form-group">
                                    <label>NOMBRE MASCOTA</label>
                                    <asp:TextBox ID="txtMascota" CssClass="form-control formulario__input" runat="server"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <label>CHIP</label>
                                    <asp:TextBox ID="txtChip" CssClass="form-control formulario__input" runat="server"></asp:TextBox>
                                </div>


                                <div class="form-group">
                                    <label for="ddlSexoMascota" class="formulario__label">SEXO</label>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlSexoMascota" runat="server" CssClass="form-control formulario__input">
                                        <asp:ListItem>Hembra</asp:ListItem>
                                        <asp:ListItem>Macho</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="evSexoMascota" runat="server" ErrorMessage="Debe ingresar un sexo" ControlToValidate="ddlSexoMascota" ForeColor="#FF3300" ValidationExpression="[a-zA-Z]{1,10}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                                </div>

                                <div class="form-group">
                                    <label for="ddlEspecie" class="formulario__label">ESPECIE</label>
                                </div>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlEspecie" runat="server" CssClass="form-control formulario__input">
                                        <asp:ListItem>CANINO</asp:ListItem>
                                        <asp:ListItem>FELINO</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Debe ingresar una especie" ControlToValidate="ddlEspecie" ForeColor="#FF3300" ValidationExpression="[a-zA-Z]{1,10}" ValidationGroup="DatosRequeridos"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div>
                        <p class="formulario__mensaje" id="formulario__mensaje">
                            <i class="fas fa-exclamation-triangle"></i>
                            <b>Error:</b> Rellene los campos correctamente
                        </p>
                    </div>
                </div>

                <div align="center">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-primary" Width="200px" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="DatosRequeridos" />
                            </td>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                            <td>
                                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" Width="200px" Text="Cancelar" />
                            </td>
                        </tr>
                    </table>
                </div>
                <br />

                <!-- Datatable Part -->

                <div class="row" style="width: 100%">
                    <div class="col-xs-12">
                        <div class="box box-primary">
                            <div class="box-header">
                                <h3 class="box-title">Lista de Pacientes</h3>
                            </div>
                            <div class="box-body table-responsive">
                                <table id="tbl_mascotas" class="table table-bordered table-hover text-center">
                                    <thead>
                                        <tr>
                                            <th>Folio</th>
                                            <th>Nombre</th>
                                            <th>Especie</th>
                                            <th>Chip</th>
                                            <th>Propietario</th>
                                            <th>ID propietario</th>
                                            <th>Acciones</th>
                                        </tr>
                                    </thead>
                                    <tbody id="tbl_body_table">
                                        <!-- DATA POR MEDIO DE AJAX-->
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- End Datatable -->
            </section>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="footer" runat="server">
    <script src="js/plugins/input-mask/jquery.inputmask.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.date.extensions.js"></script>
    <script src="js/plugins/input-mask/jquery.inputmask.extensions.js"></script>
    <script src="js/mascotas.js" type="text/javascript"></script>

</asp:Content>

$("[data-mask]").inputmask();

//Función Click para buscar pacientes
$("#btnBuscar").on('click', function (e) {
    e.preventDefault();
    var folio = $("#txtFolio").val();
    searchPacienteFolio(folio);

});


//Funcion Buscar Paciente
function searchPacienteFolio(folio) {

    var data = JSON.stringify({ folio: folio });
    $.ajax({
        type: "POST",
        url: "GestionarReservaCitas.aspx/BuscarMascotaFolio",
        data: data,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d == null) {
                alert('No exite la Mascota con el Folio ' + folio);
                limpiarDatosPaciente();
            } else {
                console.log(data.d.obj);

                llenarDatosPaciente(data.d);
            }

        }
    });



    function llenarDatosPaciente(obj) {
        $("#IdMascota").val(obj.IdMascota);
        $("#idPaciente").val(obj.IdPaciente);
        $("#txtNombres").val(obj.Paciente.Nombres);
        $("#txtApellidos").val(obj.Paciente.ApPaterno + " " + obj.Paciente.ApMaterno);
        $("txtRut").val(obj.Paciente.NroDocumento);
        $("#txtMascota").val(obj.Mascota.NombreMascota);
        $("#txtSexo").val(obj.Mascota.SexoMascota);
        //$("#txtFolio").val(obj.Mascota.Folio);
       

    }

    //Funcion AJAX actualizar
    function updateDataAjax() {

        var obj = JSON.stringify({ id: $("#idHorarioAtencion").val() });
        console.log(obj);
        $.ajax({
            type: "POST",
            url: "GestionarReservaCitas.aspx/ActualizarHorarioAtencion",
            data: obj,
            dataType: "json",
            contentType: 'application/json; charset=utf-8',
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
            },
            success: function (response) {
                if (response.d) { }
            }
        });
    }

    //Evento Click
    $(document).on('click', '.btn-registrar', function (e) {
        // e.preventDefault();
        updateDataAjax();
    });

    function limpiarDatosPaciente() {
        $("#idPaciente").val("0");
        $("#txtRut").val("");
        $("#txtNombres").val("");
        $("#txtApellidos").val("");
        $("#txtTelefono").val("");
        $("#txtEdad").val("");
        $("#txtSexo").val("");
    }
}
var tabla, data;

//Funcion para cargar la tabla
function addRowDT(data) {
    tabla = $("#tbl_mascotas").DataTable({
        "oLanguage": {
            "oPaginate": {
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
        },
        "aaSorting": [[0, 'desc']],
        "bSort": true,
        "bDestroy": true,
        "aoColumns": [
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            { "bSortable": false }
        ]
    });

    tabla.fnClearTable();

    for (var i = 0; i < data.length; i++) {
        tabla.fnAddData([
            data[i].Folio,
            data[i].NombreMascota,
            (data[i].Especie),
            (data[i].Chip),
            ((data[i].Nombres)),
            data[i].IdPaciente,
            '<button type="button" value="Actualizar" title="Actualizar" class="btn btn-primary btn-edit" data-target="#imodal" data-toggle="modal"><i class="fa fa-check-square-o" aria-hidden="true"></i></button>&nbsp;' +
            '<button type="button" value="Eliminar" title="Eliminar" class="btn btn-danger btn-delete"><i class="fa fa-minus-square-o" aria-hidden="true"></i></button>'
        ]);
    }

}


/*Funcion Para Listar Pacientes*/
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "GestionarMascotas.aspx/ListarMascota",
        data: {},
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            
            addRowDT(data.d);
            console.log(data);
        }
    });
}



$("[data-mask]").inputmask();

//Función Click para buscar pacientes
$("#btnBuscar").on('click', function (e) {
    alert(0);
    e.preventDefault();
    var rut = $("#txtDNI").val();
    searchPacienteRut(rut);

});


//Funcion Buscar Paciente
function searchPacienteRut(rut) {
    var data = JSON.stringify({ rut: rut });
    $.ajax({
        type: "POST",
        url: "GestionarMascotas.aspx/BuscarUsuarioRut",
        data: data,
        contentType: 'application/json; charset=utf-8',
        error: function (xhr, _ajaxOptions, thrownError) {
            console.log(xhr.status + " \n" + xhr.responseText, "\n" + thrownError);
        },
        success: function (data) {
            if (data.d.IdPaciente == 0) {
                alert('No exite el propietario con RUT ' + rut);
                limpiarDatosPaciente();
            } else {
                llenarDatosPaciente(data.d);
                console.log(data.d.IdPaciente);
                limpiarCampos();
            }

        }
    });
}



//Evento Click Para el boton Cancelar
$("#btnCancelar").click(function (e) {
    e.preventDefault();
    Limpiar();
});
function llenarDatosPaciente(obj) {
    $("#txtNombres").val(obj.Nombres);
    $("#txtApellidos").val(obj.ApPaterno + " " + obj.ApMaterno);
    $("#txtIdPaciente").val(obj.IdPaciente);

    alert(obj);
}

function limpiarCampos() {
}

function limpiar() {
}



sendDataAjax();
const seleccionarIcono = (nombre) => {
    $('.icono-seleccionado').removeClass('icono-seleccionado');
    $(`#${nombre}`).addClass('icono-seleccionado');
}

const obtenerVendedores = async () => {
    return await $.get('/Vendedor/GetVendedores', (data) => {
        return data;
    })
    .fail(function (error) {
            return [];
        //mostrarToast('Ha ocurrido un error', 'danger');
    });
}
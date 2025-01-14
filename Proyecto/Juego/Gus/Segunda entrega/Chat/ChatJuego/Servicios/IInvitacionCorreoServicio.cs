﻿using ChatJuego.Base_de_datos;
using ChatJuego.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using static ChatJuego.Host.Servicio;

namespace ChatJuego.Servicios
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]

    public interface IInvitacionCorreoServicio
    {
        [OperationContract(IsOneWay = false)]
        EstadoDeEnvio enviarInvitacion(Jugador jugadorInvitado, string codigoPartida, Jugador jugadorInvitador);
        [OperationContract(IsOneWay = false)]
        EstadoDeEnvio mandarCodigoDeRegistro(string codigoDeRegistro, string correo);
    }

    public enum EstadoDeEnvio
    {
        Correcto = 0,
        UsuarioNoEncontrado,
        Fallido
    }
}

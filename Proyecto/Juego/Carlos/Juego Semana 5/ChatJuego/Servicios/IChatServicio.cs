﻿using ChatJuego.Base_de_datos;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract(CallbackContract = typeof(IJugadorCallBack))]
    public interface IChatServicio
    {

        [OperationContract(IsOneWay = true)]
        void InicializarChat();

        [OperationContract(IsOneWay = true)]
        void MandarMensaje(Mensaje mensaje, Jugador jugadorQueMandaMensaje);

        [OperationContract(IsOneWay = true)]
        void MandarMensajePrivado(Mensaje mensaje, string nombreJugador, Jugador jugadorQueMandaMensaje);


        
    }
}

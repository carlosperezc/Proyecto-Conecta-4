﻿using ChatJuego.Base_de_datos;
using ChatJuego.Servicios;
using System.Collections.Generic;
using System.ServiceModel;

namespace ChatJuego.Host
{
    [ServiceContract]
    public interface IJugadorCallBack
    {
        [OperationContract(IsOneWay = true)]
        void RecibirMensaje(Jugador jugador, Mensaje mensaje,string[] nombresDeJugadores);

        [OperationContract(IsOneWay = true)]
        void ActualizarJugadoresConectados(string[] nombresDeJugadores);

        [OperationContract(IsOneWay = true)]
        void MostrarPuntajes(Jugador[] jugadores);

        [OperationContract(IsOneWay = true)]
        void IniciarPartida(string nombreOponente);

        [OperationContract(IsOneWay = true)]
        void DesconectarDePartida(EstadoPartida estadoPartida);

        [OperationContract(IsOneWay = true)]
        void InsertarFichaEnTablero(int columna);
    }
}

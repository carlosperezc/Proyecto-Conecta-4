﻿using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
using System;
using System.Collections.Generic;
using System.Windows;

namespace ChatJuego.Cliente
{
    public class JugadorCallBack : IChatServicioCallback, IInvitacionCorreoServicioCallback, IServidorCallback, ITablaDePuntajesCallback
    {
        private Chat chat;
        private VentanaDeJuego ventanaDeJuego;
        private TablaDePuntajes tabla;

        public virtual void ActualizarJugadoresConectados(string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                if (chat.UsuariosConectados != null)
                    chat.UsuariosConectados.Items.Clear();
                Jugador jugador = chat.GetJugador();
                foreach (string nombre in nombresDeJugadores)
                {
                    if (jugador.usuario != nombre)
                        chat.UsuariosConectados.Items.Add(new { UsuarioConectado = nombre });
                }
            }
        }

        public virtual void MostrarPuntajes(Jugador[] jugadores)
        {
            if (tabla != null)
            {
                int i = 1;
                foreach (Jugador jugador in jugadores)
                {
                    tabla.PlantillaTablaDePuntuaciones.Items.Add(new { FondoElemento = "00FFFFFF", FondoPosicion = "00FFFFFF", Lugar = i.ToString(), NombreJugador = jugador.usuario, Puntaje = jugador.puntaje });
                    i++;
                }
            }
        }

        public virtual void RecibirMensaje(Jugador jugador, Mensaje mensaje, string[] nombresDeJugadores)
        {
            if (chat != null)
            {
                chat.PlantillaMensaje.Items.Add(new { Posicion = "Left", FondoElemento = "White", FondoCabecera = "#7696EC", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                chat.UsuariosConectados.Items.Clear();
                ActualizarJugadoresConectados(nombresDeJugadores);
            }
        }


        public void SetTablaDePuntajes(TablaDePuntajes tabla)
        {
            this.tabla = tabla;
        }


     

        public void SetChat(Chat chat)
        {
            this.chat = chat;
        }

        public void SetVentanaDeJuego(VentanaDeJuego ventanaDeJuego)
        {
            this.ventanaDeJuego = ventanaDeJuego;
        }

        public void IniciarPartida(string nombreOponente)
        {
            if (ventanaDeJuego != null)
            {
                ventanaDeJuego.oponente = nombreOponente;
                ventanaDeJuego.oponenteConectado = true;
            }
        }

        public void DesconectarDePartida(EstadoPartida estadoPartida)
        {
            if (ventanaDeJuego != null)
                ventanaDeJuego.Desconectarse(estadoPartida);
        }

        public void InsertarFichaEnTablero(int columna)
        {
            if (ventanaDeJuego != null)
            {
                ventanaDeJuego.IntroducirFicha(columna, VentanaDeJuego.TIROOPONENTE);
                ventanaDeJuego.turnoDeJuego = true;
            }
        }
    }
}
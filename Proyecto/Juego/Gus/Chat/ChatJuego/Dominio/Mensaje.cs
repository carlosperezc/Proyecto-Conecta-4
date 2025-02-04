﻿using System;

namespace ChatJuego.Host
{
    public class Mensaje
    {
        private DateTime tiempoDeEnvio;
        private string usuarioEmisor;
        private string usuarioReceptor;
        private string contenidoMensaje;

        public DateTime TiempoDeEnvio { get => tiempoDeEnvio; set => tiempoDeEnvio = value; }
        public string UsuarioEmisor { get => usuarioEmisor; set => usuarioEmisor = value; }
        public string UsuarioReceptor { get => usuarioReceptor; set => usuarioReceptor = value; }
        public string ContenidoMensaje { get => contenidoMensaje; set => contenidoMensaje = value; }
    }
}
﻿using ChatJuego.Cliente.Proxy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private Jugador jugador;
        private ChatServicioClient servidorDelChat;
        private bool esMensajePrivado = false;
        private Label jugadorPrivadoSeleccionado;
        public MenuPrincipal menuPrincipal;
        public static Idioma idiomaChat = Idioma.Espaniol;

        public ScrollViewer VistaDeContenidoDeScroll
        {
            get { return ScrollerContenido; }
            set { ScrollerContenido = value; }
        }

        public TextBox ContenedorDelMensaje
        {
            get { return ContenidoDelMensaje; }
            set { ContenidoDelMensaje = value; }
        }

        public ItemsControl PantallaDeMensajes
        {
            get { return PlantillaMensaje; }
            set { PlantillaMensaje = value; }
        }
     

        public Label TituloDeMensaje
        {
            get { return Titulo; }
            set { Titulo = value; }
        }

        public Chat(Jugador jugador, ChatServicioClient servidorDelChat)
        {
            InitializeComponent();
            Actualizar_Idioma();
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
        }

        public Jugador GetJugador()
        {
            return jugador;
        }


        private void BotonEnviar_Click(object sender, RoutedEventArgs e)
        {
            ScrollerContenido.ScrollToBottom();
            if (!string.IsNullOrEmpty(ContenidoDelMensaje.Text))
            {
                string mensajeFinal;
                if (ContenedorDelMensaje.Text.Length > 36)
                {
                    int tamanioMensaje = ContenedorDelMensaje.Text.Length;
                    mensajeFinal = ContenedorDelMensaje.Text.Substring(0, 30);
                    mensajeFinal += System.Environment.NewLine;
                    mensajeFinal += ContenedorDelMensaje.Text.Substring(31,tamanioMensaje - 32);
                    
                } else
                {
                    mensajeFinal = ContenedorDelMensaje.Text;
                }
                if (esMensajePrivado)
                {
                    if (idiomaChat == Idioma.Ingles)
                    {
                        string mensaje = "Private message: " + mensajeFinal;
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                        servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                        esMensajePrivado = false;
                        jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                        ContenidoDelMensaje.Clear();
                    }
                    else if (idiomaChat == Idioma.Espaniol)
                    {
                        string mensaje = "Mensaje privado: " + mensajeFinal;
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                        servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                        esMensajePrivado = false;
                        jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                        ContenidoDelMensaje.Clear();
                    }
                    else if (idiomaChat == Idioma.Portugues)
                    {
                        string mensaje = "Mensagem privada: " + mensajeFinal;
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                        servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                        esMensajePrivado = false;
                        jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                        ContenidoDelMensaje.Clear();
                    }
                    else if (idiomaChat == Idioma.Frances)
                    {
                        string mensaje = "Message privé: " + mensajeFinal;
                        PlantillaMensaje.Items.Add(new { Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = DateTime.Now, MensajeEnviado = mensaje });
                        servidorDelChat.MandarMensajePrivado(new Mensaje() { ContenidoMensaje = mensaje, TiempoDeEnvio = DateTime.Now }, jugadorPrivadoSeleccionado.Content.ToString(), jugador);
                        esMensajePrivado = false;
                        jugadorPrivadoSeleccionado.Foreground = new SolidColorBrush(Colors.Black);
                        ContenidoDelMensaje.Clear();
                    }
                }
                else
                {
                    Mensaje mensaje = new Mensaje() { ContenidoMensaje = mensajeFinal, TiempoDeEnvio = DateTime.Now };
                    PlantillaMensaje.Items.Add(new {Posicion = "Right", FondoElemento = "White", FondoCabecera = "#97FFB6", Nombre = jugador.usuario, TiempoDeEnvio = mensaje.TiempoDeEnvio.ToString(), MensajeEnviado = mensaje.ContenidoMensaje });
                    servidorDelChat.MandarMensaje(mensaje, jugador);
                    ContenidoDelMensaje.Clear();
                }
            }
        }

        public static BitmapImage ConvertirArrayAImagen(byte[] arrayDeImagen)
        {
            BitmapImage imagen = new BitmapImage();
            using (MemoryStream memStream = new MemoryStream(arrayDeImagen))
            {
                imagen.BeginInit();
                imagen.CacheOption = BitmapCacheOption.OnLoad;
                imagen.StreamSource = memStream;
                imagen.EndInit();
                imagen.Freeze();
            }
            return imagen;
        }

        private void ClickEnLabelDeJugador_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Label texto = sender as Label;
            jugadorPrivadoSeleccionado = texto;
            texto.Foreground = new SolidColorBrush(Colors.Red);
            esMensajePrivado = true;
        }

      
        private void ContenidoDelMensaje_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                BotonEnviar_Click(new object(), new RoutedEventArgs());
        }

        private void Actualizar_Idioma()
        {
            if (idiomaChat == Idioma.Espaniol)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/Enviar.png", UriKind.Relative));
                Titulo.Content = "conectado";
                Jugadores_Conectados.Content = "jugadores conectados";
            }
            else if (idiomaChat == Idioma.Frances)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/EnviarFR.png", UriKind.Relative));
                Titulo.Content = "connecte";
                Jugadores_Conectados.Content = "joueurs connectes";
            }
            else if (idiomaChat == Idioma.Portugues)
            {
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/EnviarPO.png", UriKind.Relative));
                Titulo.Content = "conectado";
                Jugadores_Conectados.Content = "jogadores conectados";
            }
            else if (idiomaChat == Idioma.Ingles)
            {
                Jugadores_Conectados.Content = "Players Online";
                Titulo.Content = "Online";
                Boton_Enviar.Source = new BitmapImage(new Uri("Iconos/botonEnviarIN.png", UriKind.Relative));
            }
        }
    }
}
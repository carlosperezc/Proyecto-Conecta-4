﻿using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Media.Imaging;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente.Ventanas.Unirse_a_Partida
{
    /// <summary>
    /// Lógica de interacción para UnirseAPartida.xaml
    /// </summary>
    public partial class UnirseAPartida : Window
    {
        private ChatServicioClient servidorDelChat;
        private JugadorCallBack jugadorCallBack;
        private ServidorClient servidor;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        bool unionCorrectaAPartida = false;

        public UnirseAPartida(Jugador jugador, MenuPrincipal menuPrincipal, ChatServicioClient servidorDelChat, JugadorCallBack callBackDeJugador, ServidorClient servidor)
        {
            InitializeComponent();
            this.jugador = jugador;
            this.servidorDelChat = servidorDelChat;
            this.jugadorCallBack = callBackDeJugador;
            this.menuPrincipal = menuPrincipal;
            this.servidor = servidor;
            ActualizarIdioma();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de Unirse a Partida.
        /// Verifica con el servidor que exista la partida del código ingresado para llevarnos a la ventana de juego.
        /// </summary>
        private void BotonDeUnirseAPartida_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            if (!string.IsNullOrWhiteSpace(TBUsuarioInvitacion.Text))
            {
                try
                {
                    EstadoUnirseAPartida estado = servidor.UnirseAPartida(jugador, TBUsuarioInvitacion.Text);
                    if (estado == EstadoUnirseAPartida.Correcto)
                    {
                        unionCorrectaAPartida = true;
                        VentanaDeJuego ventanDeJuego = new VentanaDeJuego(menuPrincipal, jugador, servidorDelChat, TBUsuarioInvitacion.Text, jugadorCallBack, servidor);
                        jugadorCallBack.SetVentanaDeJuego(ventanDeJuego);
                        ventanDeJuego.Show();
                        ventanDeJuego.TurnoDeJuego = false;
                        unionCorrectaAPartida = true;
                        servidor.InicializarPartida(TBUsuarioInvitacion.Text);
                        this.Close();
                    }
                    else if (estado == EstadoUnirseAPartida.FallidoPorPartidaNoEncontrada)
                    {
                        NotificarPartidaNoEncontrada();
                    }
                    else if (estado == EstadoUnirseAPartida.FallidoPorMaximoDeJugadores)
                    {
                        NotificarPartidaMaximoJugadores();
                    }
                }
                catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                {
                    NotificarErrorDeConexion();
                    menuPrincipal.DesconexionDelServidor = true;
                    unionCorrectaAPartida = true;
                    this.Close();
                    menuPrincipal.Close();
                }
            }
            else
            {
                NotificarInformacionFaltante();
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de información requerida
        /// </summary>
        private static void NotificarInformacionFaltante()
        {
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Entrer les informations requises", "Information tronquée", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("Entre a informação requerida", "Campos incompletos", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Enter the required information", "Empty fields", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de conexion al servidor
        /// </summary>
        private static void NotificarErrorDeConexion()
        {
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("La connexion au serveur a été perdue", "Erreur de connexion", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("A conexão com o servidor foi perdida", "Error de conexão", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("The connection with the server was lost", "Connection lost", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Muestra el mensaje de partida llena
        /// </summary>
        private static void NotificarPartidaMaximoJugadores()
        {
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("Máximo de jugadores en la partida", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Plafond de joueurs atteint", "Erreur", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("Jogadores máximos no jogo", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Player limit reached", "Error", MessageBoxButton.OK);
            }
        }
        
        /// <summary>
        /// Muestra el mensaje de que la partida no fue encontrada
        /// </summary>
        private static void NotificarPartidaNoEncontrada()
        {
            MenuPrincipal.ReproducirError();
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("Partida no encontrada", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Partie non trouvé", "Erreur", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("Jogo não encontrado", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Game not found", "Error", MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_UnirseAPartida.Title = "Unirse a Partida";
                Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/tituloUnirseAPartidaES.png", UriKind.Relative));
                Ingresar_Codigo.Source = new BitmapImage(new Uri("Iconos/textoIngresarCodigoES.png", UriKind.Relative));
                Boton_Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaES.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_UnirseAPartida.Title = "Joigner Une Partie";
                Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/tituloUnirseAPartidaFR.png", UriKind.Relative));
                Ingresar_Codigo.Source = new BitmapImage(new Uri("Iconos/textoIngresarCodigoFR.png", UriKind.Relative));
                Boton_Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_UnirseAPartida.Title = "Entrar Em Um Jogo";
                Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/tituloUnirseAPartidaPO.png", UriKind.Relative));
                Ingresar_Codigo.Source = new BitmapImage(new Uri("Iconos/textoIngresarCodigoPO.png", UriKind.Relative));
                Boton_Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaPO.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_UnirseAPartida.Title = "Join Game";
                Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/tituloUnirseAPartidaEN.png", UriKind.Relative));
                Ingresar_Codigo.Source = new BitmapImage(new Uri("Iconos/textoIngresarCodigoEN.png", UriKind.Relative));
                Boton_Unirse_A_Partida.Source = new BitmapImage(new Uri("Iconos/unirse_a_partidaEN.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se cierra la ventana.
        /// Si no se encontró la partida, nos regresa al menú principal.
        /// </summary>

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!unionCorrectaAPartida)
                menuPrincipal.Show();
        }
    }
}
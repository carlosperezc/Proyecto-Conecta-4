﻿using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Configuracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer musicaDelMenu = new MediaPlayer();
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        ServidorClient servidor;
        JugadorCallBack callBackDelJugador;
        InstanceContext contexto;
        public static Configuracion.Idioma idiomaInicioSesion = Configuracion.Idioma.Espaniol;
        public MainWindow()
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidor = new ServidorClient(contexto);
            InitializeComponent();
            ActualizarIdiomaDeVentana();
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            musicaDelMenu.Open(new Uri(ruta + @"Ventanas\Sonidos\MusicaDeMenu.wav"));
            if (MenuPrincipal.EstadoMusica == 1)
            {
                musicaDelMenu.Play();
            }
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
        }

        private void BotonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPrincipal.EstadoSFX == 1)
            {
                sonidoDeBoton.Play();
            }
            if (!string.IsNullOrEmpty(TBUsuario.Text) && !string.IsNullOrEmpty(TBContrasenia.Password))
            {
                Jugador jugador = new Jugador()
                {
                    usuario = TBUsuario.Text,
                    contrasenia = TBContrasenia.Password 
                };
                try
                {
                    EstadoDeInicioDeSesion estado = servidor.Conectarse(jugador);
                    if (estado == EstadoDeInicioDeSesion.Correcto)
                    {
                        MenuPrincipal menuPrincipal = new MenuPrincipal(servidor, callBackDelJugador, jugador, contexto);
                        menuPrincipal.Show();
                        musicaDelMenu.Stop();
                        Close();
                    }
                    else if (estado == EstadoDeInicioDeSesion.Fallido)
                    {
                        if (MenuPrincipal.EstadoSFX == 1)
                        {
                            sonidoDeError.Play();
                        }
                        if (idiomaInicioSesion == Configuracion.Idioma.Espaniol)
                        {
                            MessageBox.Show("Credenciales incorrectas", "Error en el inicio de sesión", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Frances)
                        {
                            MessageBox.Show("Identifiants incorrects", "Erreur d'authentification", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Portugues)
                        {
                            MessageBox.Show("Credenciais incorrectas", "Error na autenticação", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Ingles)
                        {
                            MessageBox.Show("User or the password incorrect", "Failed to login", MessageBoxButton.OK);
                        }
                    } else if (estado == EstadoDeInicioDeSesion.FallidoPorUsuarioYaConectado)
                    {
                        if (MenuPrincipal.EstadoSFX == 1)
                        {
                            sonidoDeError.Play();
                        }
                        if (idiomaInicioSesion == Configuracion.Idioma.Espaniol)
                        {
                            MessageBox.Show("Ya hay una sesión de este usuario", "Error", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Frances)
                        {
                            MessageBox.Show("Ce utilisateur est déjà connecté", "Erreur", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Portugues)
                        {
                            MessageBox.Show("Esse usuário já está ligado", "Error", MessageBoxButton.OK);
                        }
                        else if (idiomaInicioSesion == Configuracion.Idioma.Ingles)
                        {
                            MessageBox.Show("There's already a session with this user", "Error", MessageBoxButton.OK);
                        }

                    }
                } catch (EndpointNotFoundException endpointNotFoundException)
                {
                    if (MenuPrincipal.EstadoSFX == 1)
                    {
                        sonidoDeError.Play();
                    }
                    if (idiomaInicioSesion == Configuracion.Idioma.Espaniol)
                    {
                        MessageBox.Show("No se ha podido conectar con el servidor", "Error de conexión", MessageBoxButton.OK);
                    }
                    else if (idiomaInicioSesion == Configuracion.Idioma.Frances)
                    {
                        MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                    }
                    else if (idiomaInicioSesion == Configuracion.Idioma.Portugues)
                    {
                        MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                    }
                    else if (idiomaInicioSesion == Configuracion.Idioma.Ingles)
                    {
                        MessageBox.Show("The game was unable to connect with the server", "Connection error", MessageBoxButton.OK);
                    }
                    servidor = new ServidorClient(contexto);
                }
            }
            else
            {
                if (MenuPrincipal.EstadoSFX == 1)
                {
                    sonidoDeError.Play();
                }
                if (idiomaInicioSesion == Configuracion.Idioma.Espaniol)
                {
                    MessageBox.Show("Existen campos vacíos", "Campos incompletos", MessageBoxButton.OK);
                }
                else if (idiomaInicioSesion == Configuracion.Idioma.Frances)
                {
                    MessageBox.Show("Il comprend formulaires en blanc", "Information tronquée", MessageBoxButton.OK);
                }
                else if (idiomaInicioSesion == Configuracion.Idioma.Portugues)
                {
                    MessageBox.Show("Há campos vazios", "Campos incompletos", MessageBoxButton.OK);
                }
                else if (idiomaInicioSesion == Configuracion.Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
            }
        }

        private void BotonRegistrarse_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPrincipal.EstadoSFX == 1)
            {
                sonidoDeBoton.Play();
            }
            RegistroDeJugador registro = new RegistroDeJugador(servidor,this,contexto);
            registro.Show();
            this.Hide();
        }

        private void TBContrasenia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BotonIniciarSesion_Click(new object(),new RoutedEventArgs());
            }
        }

        public void ActualizarIdiomaDeVentana()
        {
            if (idiomaInicioSesion == Configuracion.Idioma.Frances)
            {
                Ventana_Iniciar_Sesion.Title = "Ouvrir Session";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/inicio de sesionFR.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioFR.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contraseniaFR.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionFR.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseFR.png", UriKind.Relative));
            }
            else if (idiomaInicioSesion == Configuracion.Idioma.Espaniol)
            {
                Ventana_Iniciar_Sesion.Title = "Inicio de Sesión";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/inicio de sesion.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuario.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/contrasenia.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesion.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarse.png", UriKind.Relative));
            }
            else if (idiomaInicioSesion == Configuracion.Idioma.Portugues)
            {
                Ventana_Iniciar_Sesion.Title = "Autentique-se";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/tituloInicioDeSesionPO.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/textoNombreDeUsuarioPO.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaPO.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionPO.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarsePO.png", UriKind.Relative));
            }
            else if (idiomaInicioSesion == Configuracion.Idioma.Ingles)
            {
                Ventana_Iniciar_Sesion.Title = "Login";
                TextoInicioDeSesion.Source = new BitmapImage(new Uri("Iconos/tituloInicioDeSesionIN.png", UriKind.Relative));
                TextoUsuario.Source = new BitmapImage(new Uri("Iconos/usuarioIN.png", UriKind.Relative));
                TextoContrasenia.Source = new BitmapImage(new Uri("Iconos/textoContraseniaIN.png", UriKind.Relative));
                Boton_IniciarSesion.Source = new BitmapImage(new Uri("Iconos/botonIniciarSesionIN.png", UriKind.Relative));
                Boton_Registrarse.Source = new BitmapImage(new Uri("Iconos/botonRegistrarseIN.png", UriKind.Relative));
            }
        }
    }
}
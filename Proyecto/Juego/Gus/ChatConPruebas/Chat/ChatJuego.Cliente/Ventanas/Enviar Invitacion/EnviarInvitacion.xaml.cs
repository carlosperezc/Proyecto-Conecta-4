﻿using ChatJuego.Cliente.Proxy;
using ChatJuego.Cliente.Ventanas.Juego;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Shapes;
using static ChatJuego.Cliente.Ventanas.Configuracion.Configuracion;

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion.xaml
    /// </summary>
    public partial class EnviarInvitacion : Window
    {
        SoundPlayer sonidoDeBoton = new SoundPlayer();
        SoundPlayer sonidoDeError = new SoundPlayer();
        InvitacionCorreoServicioClient servidorDeCorreo;
        ChatServicioClient servidorDelChat;
        InstanceContext contexto;
        JugadorCallBack jugadorCallBack;
        ServidorClient servidor;
        private Jugador jugador;
        private MenuPrincipal menuPrincipal;
        bool perdidaDeConexion = false;
        bool juegoIniciado = false;


        public EnviarInvitacion(Jugador jugador, MenuPrincipal menuPrincipal, InstanceContext contexto, ChatServicioClient servidorDelChat, JugadorCallBack callBackDeJugador, ServidorClient servidor)
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            ruta = ruta.Substring(0, ruta.Length - 9);
            sonidoDeBoton.SoundLocation = ruta + @"Ventanas\Sonidos\ClicEnBoton.wav";
            sonidoDeError.SoundLocation = ruta + @"Ventanas\Sonidos\Error.wav";
            InitializeComponent();
            Actualizar_Idioma();
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
            this.contexto = contexto;
            this.servidorDelChat = servidorDelChat;
            this.jugadorCallBack = callBackDeJugador;
            this.servidor = servidor;
        }

        private void BotonDeEnviarInvitacion_Click(object sender, RoutedEventArgs e)
        {
            sonidoDeBoton.Play();
            if (!string.IsNullOrEmpty(TBUsuarioInvitacion.Text))
            {
                if (jugador.usuario != TBUsuarioInvitacion.Text)
                {
                    try
                    {
                        servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
                        string codigoDePartida = GenerarCodigoDePartida().ToString();
                        var estado = servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = TBUsuarioInvitacion.Text }, codigoDePartida, jugador);
                        if (estado == EstadoDeEnvio.UsuarioNoEncontrado)
                        {
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("El usuario ingresado no existe", "Usuario no encontrado", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("The user does not exist", "User not found", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Cet utilisateur n'existe pas", "Utilisateur n'est pas trouvée", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("O usuário não existe", "Usuário não encontrado", MessageBoxButton.OK);
                            }
                        }
                        else if (estado == EstadoDeEnvio.Fallido)
                        {
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("Ocurrió un error y no se pudo mandar la invitación", "Error", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("Something happened and we coudln´t send the invitation", "Error", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Something happened and we coudln´t send the invitation", "Erreur", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("Acountecou um error e a convite não pudo ser enviada", "Error", MessageBoxButton.OK);
                            }
                        }
                        else
                        {
                            if (idioma == Idioma.Espaniol)
                            {
                                MessageBox.Show("Invitación enviada", "Correcto", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Ingles)
                            {
                                MessageBox.Show("Invitation sent", "Correct", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Frances)
                            {
                                MessageBox.Show("Invitation adressée", "Correct", MessageBoxButton.OK);
                            }
                            else if (Ventanas.Configuracion.Configuracion.idioma == Idioma.Portugues)
                            {
                                MessageBox.Show("Convite enviada", "Correct", MessageBoxButton.OK);
                            }
                            VentanaDeJuego ventanaDeJuego = new VentanaDeJuego(contexto, menuPrincipal, jugador, servidorDelChat, codigoDePartida, jugadorCallBack, servidor);
                            ventanaDeJuego.Show();
                            ventanaDeJuego.turnoDeJuego = true;
                            jugadorCallBack.SetVentanaDeJuego(ventanaDeJuego);
                            juegoIniciado = true;
                            this.Close();
                        }
                    }
                    catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
                    {
                        if (idioma == Idioma.Espaniol)
                        {
                            MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Ingles)
                        {
                            MessageBox.Show("The connection with the server was lost", "Connection lost", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Frances)
                        {
                            MessageBox.Show("La connexion au serveur été perdue", "Connexion perdue", MessageBoxButton.OK);
                        }
                        else if (idioma == Idioma.Portugues)
                        {
                            MessageBox.Show("A conexão foi perdida", "Conexão perdida", MessageBoxButton.OK);
                        }
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        perdidaDeConexion = true;
                        menuPrincipal.Close();
                        this.Close();
                    }
                } else
                {
                    sonidoDeError.Play();
                    if (idioma == Idioma.Espaniol)
                    {
                        MessageBox.Show("No te puedes invitar a ti mismo", "Usuario inválido", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Ingles)
                    {
                        MessageBox.Show("You can not send an invitation to yourself", "Invalid user", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Frances)
                    {
                        MessageBox.Show("Vous ne puvez pasinviter vous - même", "Utilisateur invalite", MessageBoxButton.OK);
                    }
                    else if (idioma == Idioma.Portugues)
                    {
                        MessageBox.Show("Você nao pode convidar você mesmo", "Usuário inválido", MessageBoxButton.OK);
                    }
                }
            } else
            {
                sonidoDeError.Play();
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Ingrese la información requerida", "Campos vacíos", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("Input the information required", "Empty fields", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Entrez les information requises", "Information tronquée", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Ingresse os datos requeridos", "Campos incompletos", MessageBoxButton.OK);
                }
            }
        }

        public static int GenerarCodigoDePartida()
        {
            return new Random().Next(1000, 3000);
        }

        private void Actualizar_Idioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Invitación";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacion.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuario.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacion.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Envio_Invitacion.Title = "Envoyer Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionFR.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioFR.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionFR.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Envio_Invitacion.Title = "Enviar Convite";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionPO.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioPO.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionPO.png", UriKind.Relative));
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Envio_Invitacion.Title = "Send Invitation";
                Envio_De_Invitacion.Source = new BitmapImage(new Uri("Iconos/envioInvitacionIN.png", UriKind.Relative));
                Ingrese_Usuario.Source = new BitmapImage(new Uri("Iconos/ingresarUsuarioIN.png", UriKind.Relative));
                Boton_Enviar_Invitacion.Source = new BitmapImage(new Uri("Iconos/botonEnviarInvitacionIN.png", UriKind.Relative));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           if (!perdidaDeConexion && !juegoIniciado)
                menuPrincipal.Show();   
        }
    }
}

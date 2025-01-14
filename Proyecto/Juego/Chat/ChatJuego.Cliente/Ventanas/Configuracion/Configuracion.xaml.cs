﻿using System;
using System.Windows;
using System.Windows.Media.Imaging;
using ChatJuego.Cliente.Proxy;
using System.ServiceModel;

namespace ChatJuego.Cliente.Ventanas.Configuracion
{
    /// <summary>
    /// Lógica de interacción para Configuracion.xaml
    /// </summary>
    public partial class Configuracion : Window
    {
        private MenuPrincipal menuPrincipal;
        public static Idioma idioma = Idioma.Espaniol;
        private ServidorClient servidor;
        private Jugador jugador;
        private bool eliminarJugador = false;

        public Configuracion(MenuPrincipal menuPrincipal, ServidorClient servidor, Jugador jugador)
        {
            InitializeComponent();
            ActualizarIdioma();
            this.servidor = servidor;
            this.jugador = jugador;
            this.menuPrincipal = menuPrincipal;
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el Botón de Eliminar cuenta;
        /// Elimina la cuenta del usuario que tiene la sesión iniciada
        /// </summary>
        private void EliminarCuenta_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            try
            {
                if (idioma == Idioma.Espaniol)
                {
                    if (MessageBox.Show("¿Estás seguro que quieres eliminar tu cuenta?", "Eliminar cuenta", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        if (servidor.EliminarJugador(jugador) == EstadoDeEliminacion.Correcto)
                        {
                            eliminarJugador = true;
                            this.Close();
                        }
                        else
                        {
                            NotificarErrorElminarCuenta();
                        }
                    }

                }

                else if (idioma == Idioma.Frances)
                {
                    if (MessageBox.Show("Êtes-vous sûr de vouloir supprimer votre compte?", "Supprimer compte", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        if (servidor.EliminarJugador(jugador) == EstadoDeEliminacion.Correcto)
                        {
                            eliminarJugador = true;
                            this.Close();
                        }
                        else
                        {
                            NotificarErrorElminarCuenta();
                        }

                    }


                }
                else if (idioma == Idioma.Portugues)
                {
                    if (MessageBox.Show("Queres mesmo apagar esta conta?", "Apagar conta", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        if (servidor.EliminarJugador(jugador) == EstadoDeEliminacion.Correcto)
                        {
                            eliminarJugador = true;
                            this.Close();
                        }
                        else
                        {
                            NotificarErrorElminarCuenta();
                        }

                    }

                }

                else if (idioma == Idioma.Ingles)
                {
                    if (MessageBox.Show("Do you really want to delete this account?", "Delete account", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {

                        if (servidor.EliminarJugador(jugador) == EstadoDeEliminacion.Correcto)
                        {
                            eliminarJugador = true;
                            this.Close();
                        }
                        else
                        {
                            NotificarErrorElminarCuenta();
                        }

                    }

                }

            }
            catch (Exception exception) when (exception is TimeoutException || exception is EndpointNotFoundException)
            {
                MenuPrincipal.ReproducirError();
                if (idioma == Idioma.Espaniol)
                {
                    MessageBox.Show("Se perdió la conexión con el servidor", "Error de conexión", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Ingles)
                {
                    MessageBox.Show("The connection with the server was lost", "Conenction lost", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Frances)
                {
                    MessageBox.Show("Le server ne peut connecter", "Échec de connexion", MessageBoxButton.OK);
                }
                else if (idioma == Idioma.Portugues)
                {
                    MessageBox.Show("Erro ao se conectar ao servidor", "Falha da conexão", MessageBoxButton.OK);
                }
            }
        }

        /// <summary>
        /// Muestra el mensaje de error de eliminar la cuenta
        /// </summary>
        private void NotificarErrorElminarCuenta()
        {
            MenuPrincipal.ReproducirError();
            if (idioma == Idioma.Espaniol)
            {
                MessageBox.Show("No se pudo eliminar la cuenta", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Ingles)
            {
                MessageBox.Show("Unable to delete the account", "Error", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Frances)
            {
                MessageBox.Show("Le compte n'a pas pu être supprimé", "Erreur", MessageBoxButton.OK);
            }
            else if (idioma == Idioma.Portugues)
            {
                MessageBox.Show("A conta não pôde ser excluída", "Erro", MessageBoxButton.OK);
            }
        }
        /// <summary>
        /// Método que se ejecuta cuando se desactiva o activa la música
        /// </summary>

        private void Musica_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            if (MenuPrincipal.EstadoMusica == MenuPrincipal.EFECTOS_ENCENDIDO)
            {
                MenuPrincipal.MusicaDeMenu.Stop();
                MenuPrincipal.EstadoMusica = MenuPrincipal.EFECTOS_APAGADO;
                ActualizarIdioma();
            }
            else
            {
                MenuPrincipal.MusicaDeMenu.Play();
                MenuPrincipal.EstadoMusica = MenuPrincipal.EFECTOS_ENCENDIDO;
                ActualizarIdioma();
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se desactivan o activan los efectos de sonido
        /// </summary>
        private void SFX_Click(object sender, RoutedEventArgs e)
        {
            if (MenuPrincipal.EstadoSFX == MenuPrincipal.EFECTOS_ENCENDIDO)
            {
                MenuPrincipal.EstadoSFX = MenuPrincipal.EFECTOS_APAGADO;
                ActualizarIdioma();
            }
            else
            {
                MenuPrincipal.EstadoSFX = MenuPrincipal.EFECTOS_ENCENDIDO;
                MenuPrincipal.ReproducirBoton();
                ActualizarIdioma();
            }
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de idioma Inglés.
        /// Se cambia el idioma seleccionado a inglés.
        /// </summary>

        private void Ingles_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Ingles;
            ActualizarIdioma();
            menuPrincipal.ActualizarIdioma();
        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de idioma Español.
        /// Se cambia el idioma seleccionado a español.
        /// </summary>
        private void Espaniol_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Espaniol;
            ActualizarIdioma();
            menuPrincipal.ActualizarIdioma();

        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de idioma Francés.
        /// Se cambia el idioma seleccionado a francés.
        /// </summary>
        private void Frances_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Frances;
            ActualizarIdioma();
            menuPrincipal.ActualizarIdioma();

        }

        /// <summary>
        /// Método que se ejecuta cuando se da click en el botón de idioma Portugués.
        /// Se cambia el idioma seleccionado a portugués.
        /// </summary>
        private void Portugues_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal.ReproducirBoton();
            idioma = Idioma.Portugues;
            ActualizarIdioma();
            menuPrincipal.ActualizarIdioma();

        }

        /// <summary>
        /// Actualiza el idioma de la ventana dependiendo del idioma seleccionado en la ventana de Configuración
        /// </summary>
        private void ActualizarIdioma()
        {
            if (idioma == Idioma.Espaniol)
            {
                Ventana_Configuracion.Title = "Configuración";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniolON.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/configuracion.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdioma.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/musica.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/SFX.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuenta.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonOFFES.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonONES.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonOFFES.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonONES.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Frances)
            {
                Ventana_Configuracion.Title = "Configuration";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrancesON.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/tituloConfiguracionFR.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaFR.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusicaFR.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXFR.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaFR.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonApagadoFR.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonEncendidoFR.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonApagadoFR.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonEncendidoFR.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Portugues)
            {
                Ventana_Configuracion.Title = "Configuração";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoIngles.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortuguesON.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/tituloConfiguracionPO.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaPO.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusicaPO.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXPO.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaPO.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonApagadoPO.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonEncendidoPO.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonApagadoPO.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonEncendidoPO.png", UriKind.Relative));
                }
            }
            else if (idioma == Idioma.Ingles)
            {
                Ventana_Configuracion.Title = "Configuration";
                Boton_Frances.Source = new BitmapImage(new Uri("Iconos/textoFrances.png", UriKind.Relative));
                Boton_Espaniol.Source = new BitmapImage(new Uri("Iconos/textoEspaniol.png", UriKind.Relative));
                Boton_Ingles.Source = new BitmapImage(new Uri("Iconos/textoInglesON.png", UriKind.Relative));
                Boton_Portugues.Source = new BitmapImage(new Uri("Iconos/textoPortugues.png", UriKind.Relative));
                TituloVentana.Source = new BitmapImage(new Uri("Iconos/configuracionEN.png", UriKind.Relative));
                TextoIdioma.Source = new BitmapImage(new Uri("Iconos/textoIdiomaEN.png", UriKind.Relative));
                ConfigMusica.Source = new BitmapImage(new Uri("Iconos/textoMusica.png", UriKind.Relative));
                ConfigSFX.Source = new BitmapImage(new Uri("Iconos/textoSFXEN.png", UriKind.Relative));
                Boton_EliminarCuenta.Source = new BitmapImage(new Uri("Iconos/botonEliminarCuentaEN.png", UriKind.Relative));
                if (MenuPrincipal.EstadoMusica != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonOFF.png", UriKind.Relative));
                }
                else
                {
                    Boton_Musica.Source = new BitmapImage(new Uri("Iconos/botonON.png", UriKind.Relative));
                }
                if (MenuPrincipal.EstadoSFX != MenuPrincipal.EFECTOS_ENCENDIDO)
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonOFF.png", UriKind.Relative));
                }
                else
                {
                    Boton_SFX.Source = new BitmapImage(new Uri("Iconos/botonON.png", UriKind.Relative));
                }
            }
        }

        /// <summary>
        /// Se define el enum donde cada idioma corresponde a un valor
        /// </summary>
        public enum Idioma
        {
            Espaniol = 0,
            Ingles,
            Frances,
            Portugues
        }

        /// <summary>
        /// Se ejecuta cuando se cierra la ventana. Si se eliminó el usuario, se cierra el menú principal para regresar a la ventana de iniciar sesión
        /// </summary>

        private void Ventana_Configuracion_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (eliminarJugador)
            {
                menuPrincipal.CuentaEliminada = true;
                menuPrincipal.Close();
            }
        }
    }
}

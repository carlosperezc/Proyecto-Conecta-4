﻿using ChatJuego.Servicios;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ChatJuego.Base_de_datos
{
    /// <summary>
    /// Lógica de administración de la base de datos
    /// </summary>
    public class Autenticacion
    {

        public Autenticacion ()
        {
        }

        /// <summary>
        /// Permite el registro de un jugador en la base de datos.
        /// </summary>
        /// <param name="usuarioARegistrar">Usuario del jugador.</param>
        /// <param name="contraseniaARegistrar">Contraseña del jugador-</param>
        /// <param name="correoARegistrar">Correo del jugador.</param>
        /// <param name="imagenDeJugador">Arreglo de bytes de la imagen del jugador.</param>
        /// <returns></returns>
        public EstadoDeRegistro Registrar(string usuarioARegistrar, string contraseniaARegistrar, string correoARegistrar, byte[] imagenDeJugador)
        {
            EstadoDeRegistro estado;
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuarioARegistrar
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorUsuario;
                    return estado;
                }
                jugadores = (from jugador in contexto.jugadores
                                 where jugador.correo == correoARegistrar
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeRegistro.FallidoPorCorreo;
                    return estado;
                }
                contexto.jugadores.Add(new Jugador() { usuario = usuarioARegistrar, contrasenia = CifrarContrasenia(contraseniaARegistrar), correo = correoARegistrar, puntaje = 0 , imagenUsuario = imagenDeJugador });
                contexto.SaveChanges();
                estado = EstadoDeRegistro.Correcto;
                return estado;
            }
        }

        /// <summary>
        /// Verifica que las credenciales de inicio de sesión sean correctas para permitir el inicio de sesión.
        /// </summary>
        /// <param name="usuario">Usuario del jugador.</param>
        /// <param name="contrasenia">Contraseña del jugador.</param>
        /// <returns>Regresa un estado de autenticación, true si son correctas las credenciales y false si son incorrectas.</returns>
        public EstadoDeAutenticacion IniciarSesion(string usuario, string contrasenia)
        {
            EstadoDeAutenticacion estado = EstadoDeAutenticacion.Failed;
            string contraseniaCifrada = CifrarContrasenia(contrasenia);
            using (var contexto = new JugadorContexto())
            {
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario && jugador.contrasenia == contraseniaCifrada
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    estado = EstadoDeAutenticacion.Correcto;
                }
            }
            return estado;
        }

        /// <summary>
        /// Permite cifrar la contraseña del usuario para que no se pueda consultar desde la base de datos.
        /// </summary>
        /// <param name="contrasenia"></param>
        /// <returns></returns>
        private string CifrarContrasenia(string contrasenia)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasenia));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Elimina un jugador de la base de datos.
        /// </summary>
        /// <param name="usuario">Usuario del jugador.</param>
        /// <param name="contrasenia">Contraseña del jugador.</param>
        /// <returns>Regresa un estado de eliminación, es decir, correcto o fallido.</returns>
        internal EstadoDeEliminacion EliminarJugador(string usuario, string contrasenia)
        {
            EstadoDeEliminacion estado;
            using (var contexto = new JugadorContexto())
            {
                string contraseniaCifrada = CifrarContrasenia(contrasenia);
                var jugadores = (from jugador in contexto.jugadores
                                 where jugador.usuario == usuario && jugador.contrasenia == contraseniaCifrada
                                 select jugador).Count();
                if (jugadores > 0)
                {
                    contexto.jugadores.Remove(contexto.jugadores.Single(a => a.usuario == usuario && a.contrasenia == contraseniaCifrada));
                    contexto.SaveChanges();
                    estado = EstadoDeEliminacion.Correcto;
                }
                else
                    estado = EstadoDeEliminacion.Fallido;
            }
            return estado;
        }
    }

    /// <summary>
    /// Enum que define el estado de autenticación, siendo correcto o fallido los valores posibles.
    /// </summary>
    public enum EstadoDeAutenticacion
    {
        Correcto = 0,
        Failed
    }

 

}

﻿using ChatJuego.Cliente;
using ChatJuego.Cliente.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

namespace Pruebas
{
    [TestClass]
    public class PruebasIInvitacionPorCorreo
    {
        private static JugadorCallBack callBackDelJugador;
        private static InstanceContext contexto;
        private static InvitacionCorreoServicioClient servidorDeCorreo;

        [ClassInitialize]
        public static void Inicializar(TestContext testContext)
        {
            callBackDelJugador = new JugadorCallBack();
            contexto = new InstanceContext(callBackDelJugador);
            servidorDeCorreo = new InvitacionCorreoServicioClient(contexto);
        }
        [TestMethod]
        public void TestEnviarInvitacionCorrecto()
        {
            Assert.AreEqual(EstadoDeEnvio.Correcto, servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "Gustavo825" }, "0000", new Jugador() { usuario = "Pruebas" }));
        }

        [TestMethod]
        public void TestEnviarInvitacionUsuarioNoEncontrado()
        {
            Assert.AreEqual(EstadoDeEnvio.UsuarioNoEncontrado, servidorDeCorreo.EnviarInvitacion(new Jugador() { usuario = "UsuarioInexistente" }, "0000", new Jugador() { usuario = "Pruebas" }));
        }

        [TestMethod]
        public void TestMandarCodigoDeRegistroCorrecto()
        {
            Assert.AreEqual(EstadoDeEnvio.Correcto, servidorDeCorreo.MandarCodigoDeRegistro("1234","gusttavo_floress@hotmail.com"));
        }
    }
}

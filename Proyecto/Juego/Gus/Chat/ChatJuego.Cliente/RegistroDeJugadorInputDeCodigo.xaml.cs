﻿using System;
using System.Collections.Generic;
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

namespace ChatJuego.Cliente
{
    /// <summary>
    /// Lógica de interacción para EnviarInvitacion_InputDeCodigo.xaml
    /// </summary>
    public partial class RegistroDeJugador_InputDeCodigo : Window
    {
        private int codigoDeRegistro;

        public RegistroDeJugador_InputDeCodigo(int codigoDeRegistro)
        {
            InitializeComponent();
            this.codigoDeRegistro = codigoDeRegistro;

        }

        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            if (txtAnswer.Text.Equals(codigoDeRegistro.ToString()))
                this.DialogResult = true;
            else

                this.DialogResult = false;

        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            txtAnswer.SelectAll();
            txtAnswer.Focus();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

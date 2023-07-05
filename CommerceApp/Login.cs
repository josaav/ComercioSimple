﻿using Aplicacion.Constantes;
using IServicio.Seguridad;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommerceApp
{
    public partial class Login : Form
    {
        private readonly ISeguridadServicio _seguridadServicio;

        public bool puedeAccederAlSistema { get; set; }
        public Login(ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            _seguridadServicio = seguridadServicio;

            //TODO - USUARIO
            txtUsuario.Text = "jsaavedra";
            txtPassword.Text = "P$assword123";
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (UsuarioAdmin.Usuario == txtUsuario.Text && UsuarioAdmin.Password == txtPassword.Text)
            {
                Identidad.Usuario = "Administrador";

                puedeAccederAlSistema = true;

                this.Close();

                return;
            }
            var puedeAcceder = _seguridadServicio.VerificarAcceso(txtUsuario.Text, txtPassword.Text);

            if (puedeAcceder == false)
            {
                MessageBox.Show("El usuario o contraseña son incorrectos");
                txtPassword.Clear();

            }
            else
            {
                var CurrentUsuario = _seguridadServicio.ObtenerUsuarioLogin(txtUsuario.Text);

                if (CurrentUsuario == null) throw new Exception("Ocurrió un error al obtener el usuario");

                if (CurrentUsuario.EstaBloqueado)
                {
                    MessageBox.Show($"El usuario {CurrentUsuario.ApyNomEmpleado} está bloqueado",
                        "Atención",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Stop);

                    txtUsuario.Clear();
                    txtPassword.Clear();
                    return;
                }

                Identidad.EmpleadoId = CurrentUsuario.EmpleadoId;
                Identidad.Nombre = CurrentUsuario.NombreEmpleado;
                Identidad.Apellido = CurrentUsuario.ApellidoEmpleado;
                Identidad.Foto = CurrentUsuario.FotoEmpleado;

                Identidad.UsuarioId = CurrentUsuario.Id;
                Identidad.Usuario = CurrentUsuario.NombreUsuario;

                puedeAccederAlSistema = puedeAcceder;
    

                if (puedeAccederAlSistema)
                {
                    
                    Principal panelPrincipal = ObjectFactory.GetInstance<Principal>();
                    this.Hide();
                    panelPrincipal.ShowDialog();
                    this.Close();
                }
              
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void botonLogin_MouseHover(object sender, EventArgs e)
        {
            botonLogin.BackColor = System.Drawing.Color.White;
        }


        private void botonLogin_Click(object sender, EventArgs e)
        {
            if (UsuarioAdmin.Usuario == txtUsuario.Text && UsuarioAdmin.Password == txtPassword.Text)
            {
                Identidad.Usuario = "Administrador";

                puedeAccederAlSistema = true;

                this.Close();

                return;
            }
            var puedeAcceder = _seguridadServicio.VerificarAcceso(txtUsuario.Text, txtPassword.Text);

            if (puedeAcceder == false)
            {
                MessageBox.Show("El usuario o contraseña son incorrectos");
                txtPassword.Clear();

            }
            else
            {
                var CurrentUsuario = _seguridadServicio.ObtenerUsuarioLogin(txtUsuario.Text);

                if (CurrentUsuario == null) throw new Exception("Ocurrió un error al obtener el usuario");

                if (CurrentUsuario.EstaBloqueado)
                {
                    MessageBox.Show($"El usuario {CurrentUsuario.ApyNomEmpleado} está bloqueado",
                        "Atención",
                        MessageBoxButtons.OKCancel,
                        MessageBoxIcon.Stop);

                    txtUsuario.Clear();
                    txtPassword.Clear();
                    return;
                }

                Identidad.EmpleadoId = CurrentUsuario.EmpleadoId;
                Identidad.Nombre = CurrentUsuario.NombreEmpleado;
                Identidad.Apellido = CurrentUsuario.ApellidoEmpleado;
                Identidad.Foto = CurrentUsuario.FotoEmpleado;

                Identidad.UsuarioId = CurrentUsuario.Id;
                Identidad.Usuario = CurrentUsuario.NombreUsuario;

                puedeAccederAlSistema = puedeAcceder;


                if (puedeAccederAlSistema)
                {

                    Principal panelPrincipal = ObjectFactory.GetInstance<Principal>();
                    this.Hide();
                    panelPrincipal.ShowDialog();
                    this.Close();
                }

            }
        }
    }
}

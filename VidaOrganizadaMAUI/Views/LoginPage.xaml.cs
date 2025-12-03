using System;
using Microsoft.Maui.Controls;
using VidaOrganizadaMAUI.Models;
using System.Linq;

namespace VidaOrganizadaMAUI.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var usuarioTexto = entryUsuario.Text?.Trim();
            var contrasenaTexto = entryContrasena.Text?.Trim();

            if (string.IsNullOrWhiteSpace(usuarioTexto) || string.IsNullOrWhiteSpace(contrasenaTexto))
            {
                lblMensaje.Text = "Ingresa usuario y contraseña.";
                lblMensaje.IsVisible = true;
                return;
            }

            // Validación contra SQLite
            var usuario = await App.Database.Table<Usuarios>()
                             .Where(u => u.Usuario == usuarioTexto && u.Contrasena == contrasenaTexto)
                             .FirstOrDefaultAsync();

            if (usuario != null)
            {
                lblMensaje.IsVisible = false;
                // Navegar a MainPage, pasando el nombre para saludo
                await Navigation.PushAsync(new MainPage(usuario.Nombre ?? usuario.Usuario));
                // Opcional: limpiar entradas
                entryContrasena.Text = string.Empty;
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
                lblMensaje.IsVisible = true;
            }
        }
    }
}

using System;
using Microsoft.Maui.Controls;

namespace VidaOrganizadaMAUI.Views
{
    public partial class MainPage : ContentPage
    {
        private string usuarioNombre;

        public MainPage(string nombreUsuario)
        {
            InitializeComponent();
            usuarioNombre = nombreUsuario;
            lblSaludo.Text = $"Hola, {usuarioNombre} ¡Bienvenido!";
        }

        private async void OpenTareas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TareasPage());
        }

        private async void OpenCalendario(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CalendarioPage());
        }

        private async void OpenHabitos(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HabitosPage());
        }

        private async void OpenNotas(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotasPage());
        }

        private async void CerrarSesion(object sender, EventArgs e)
        {
            // Vuelve al login (remueve stack)
            await Navigation.PopToRootAsync();
        }
    }
}

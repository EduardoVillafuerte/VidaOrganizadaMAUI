using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using VidaOrganizadaMAUI.Models;

namespace VidaOrganizadaMAUI.Views
{
    public partial class NotasPage : ContentPage
    {
        private ObservableCollection<Nota> notasList = new ObservableCollection<Nota>();

        public NotasPage()
        {
            InitializeComponent();
            cvNotas.ItemsSource = notasList;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadNotas();
        }

        private async System.Threading.Tasks.Task LoadNotas()
        {
            var items = await App.Database.Table<Nota>().OrderByDescending(n => n.FechaCreacion).ToListAsync();
            notasList.Clear();
            foreach (var n in items) notasList.Add(n);
        }

        private async void AgregarNota_Clicked(object sender, EventArgs e)
        {
            var titulo = entryNotaTitulo.Text?.Trim();
            var contenido = editorContenido.Text?.Trim();

            if (string.IsNullOrWhiteSpace(titulo) && string.IsNullOrWhiteSpace(contenido))
            {
                await DisplayAlert("Error", "Agrega un título o contenido para la nota.", "OK");
                return;
            }

            var nota = new Nota
            {
                Titulo = titulo,
                Contenido = contenido,
                FechaCreacion = DateTime.Now
            };

            await App.Database.InsertAsync(nota);
            entryNotaTitulo.Text = string.Empty;
            editorContenido.Text = string.Empty;
            await LoadNotas();
        }

        private async void EliminarNota_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is int id)
            {
                var nota = await App.Database.FindAsync<Nota>(id);
                if (nota != null)
                {
                    var confirma = await DisplayAlert("Eliminar", "¿Eliminar esta nota?", "Sí", "No");
                    if (confirma)
                    {
                        await App.Database.DeleteAsync(nota);
                        await LoadNotas();
                    }
                }
            }
        }
    }
}

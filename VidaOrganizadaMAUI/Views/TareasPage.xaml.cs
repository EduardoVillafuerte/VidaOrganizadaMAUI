using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using VidaOrganizadaMAUI.Models;

namespace VidaOrganizadaMAUI.Views
{
    public partial class TareasPage : ContentPage
    {
        private ObservableCollection<Tarea> tareasList = new ObservableCollection<Tarea>();

        public TareasPage()
        {
            InitializeComponent();
            cvTareas.ItemsSource = tareasList;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadTareas();
        }

        private async System.Threading.Tasks.Task LoadTareas()
        {
            var items = await App.Database.Table<Tarea>().OrderByDescending(t => t.FechaCreacion).ToListAsync();
            tareasList.Clear();
            foreach (var t in items) tareasList.Add(t);
        }

        private async void AgregarTarea_Clicked(object sender, EventArgs e)
        {
            var titulo = entryTitulo.Text?.Trim();
            var descripcion = entryDescripcion.Text?.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
            {
                await DisplayAlert("Error", "El título es obligatorio.", "OK");
                return;
            }

            var tarea = new Tarea
            {
                Titulo = titulo,
                Descripcion = descripcion,
                Completada = false,
                FechaCreacion = DateTime.Now
            };

            await App.Database.InsertAsync(tarea);
            entryTitulo.Text = string.Empty;
            entryDescripcion.Text = string.Empty;
            await LoadTareas();
        }

        private async void Eliminar_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is int id)
            {
                var tarea = await App.Database.FindAsync<Tarea>(id);
                if (tarea != null)
                {
                    var confirma = await DisplayAlert("Eliminar", "¿Eliminar esta tarea?", "Sí", "No");
                    if (confirma)
                    {
                        await App.Database.DeleteAsync(tarea);
                        await LoadTareas();
                    }
                }
            }
        }
    }
}

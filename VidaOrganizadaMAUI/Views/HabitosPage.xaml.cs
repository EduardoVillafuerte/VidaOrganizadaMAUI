using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using VidaOrganizadaMAUI.Models;

namespace VidaOrganizadaMAUI.Views
{
    public partial class HabitosPage : ContentPage
    {
        private ObservableCollection<Habito> habitosList = new ObservableCollection<Habito>();

        public HabitosPage()
        {
            InitializeComponent();
            cvHabitos.ItemsSource = habitosList;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadHabitos();
        }

        private async System.Threading.Tasks.Task LoadHabitos()
        {
            var items = await App.Database.Table<Habito>().OrderBy(h => h.Nombre).ToListAsync();
            habitosList.Clear();
            foreach (var h in items) habitosList.Add(h);
        }

        private async void AgregarHabito_Clicked(object sender, EventArgs e)
        {
            var nombre = entryHabitoNombre.Text?.Trim();
            var frecuencia = entryHabitoFrecuencia.Text?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                await DisplayAlert("Error", "El nombre del hábito es obligatorio.", "OK");
                return;
            }

            var habito = new Habito
            {
                Nombre = nombre,
                Frecuencia = frecuencia,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            await App.Database.InsertAsync(habito);
            entryHabitoNombre.Text = string.Empty;
            entryHabitoFrecuencia.Text = string.Empty;
            await LoadHabitos();
        }

        private async void EliminarHabito_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is int id)
            {
                var habito = await App.Database.FindAsync<Habito>(id);
                if (habito != null)
                {
                    var confirma = await DisplayAlert("Eliminar", "¿Eliminar este hábito?", "Sí", "No");
                    if (confirma)
                    {
                        await App.Database.DeleteAsync(habito);
                        await LoadHabitos();
                    }
                }
            }
        }
    }
}

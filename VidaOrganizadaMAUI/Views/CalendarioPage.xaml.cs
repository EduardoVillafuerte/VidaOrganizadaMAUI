using System.Collections.ObjectModel;
using VidaOrganizadaMAUI.Models;

namespace VidaOrganizadaMAUI.Views
{
    public partial class CalendarioPage : ContentPage
    {
        private ObservableCollection<Evento> eventosList = new ObservableCollection<Evento>();

        public CalendarioPage()
        {
            InitializeComponent();
            cvEventos.ItemsSource = eventosList;
            datePickerEvento.Date = DateTime.Today;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadEventos();
        }

        private async Task LoadEventos()
        {
            var items = await App.Database.Table<Evento>().OrderBy(e => e.FechaEvento).ToListAsync();
            eventosList.Clear();
            foreach (var ev in items)
                eventosList.Add(ev);
        }

        private async void AgregarEvento_Clicked(object sender, EventArgs e)
        {
            var titulo = entryEventoTitulo.Text?.Trim();
            var descripcion = entryEventoDescripcion.Text?.Trim();
            var fecha = datePickerEvento.Date;

            if (string.IsNullOrEmpty(titulo))
            {
                await DisplayAlert("Error", "El título es obligatorio.", "OK");
                return;
            }

            var evento = new Evento
            {
                Titulo = titulo,
                Descripcion = descripcion,
                FechaEvento = fecha,
                FechaCreacion = DateTime.Now
            };

            await App.Database.InsertAsync(evento);
            entryEventoTitulo.Text = "";
            entryEventoDescripcion.Text = "";
            await LoadEventos();
        }

        private async void EliminarEvento_Clicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is int id)
            {
                var evento = await App.Database.FindAsync<Evento>(id);

                if (evento != null)
                {
                    var confirmar = await DisplayAlert("Eliminar", "¿Eliminar este evento?", "Sí", "No");
                    if (confirmar)
                    {
                        await App.Database.DeleteAsync(evento);
                        await LoadEventos();
                    }
                }
            }
        }
    }
}

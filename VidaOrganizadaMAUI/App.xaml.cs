using System;
using System.IO;
using SQLite;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace VidaOrganizadaMAUI
{
    public partial class App : Application
    {
        public static SQLiteAsyncConnection? Database { get; private set; }

        public App()
        {
            InitializeComponent();

            InitializeDatabaseAsync();

            MainPage = new NavigationPage(new Views.LoginPage());
        }

        private async void InitializeDatabaseAsync()
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "vidaorganizada.db3");
            Database = new SQLiteAsyncConnection(dbPath);

            await Database.CreateTableAsync<Models.Usuarios>();
            await Database.CreateTableAsync<Models.Tarea>();
            await Database.CreateTableAsync<Models.Evento>();
            await Database.CreateTableAsync<Models.Habito>();
            await Database.CreateTableAsync<Models.Nota>();

            var usuarios = await Database.Table<Models.Usuarios>().ToListAsync();

            if (usuarios.Count == 0)
            {
                var admin = new Models.Usuarios
                {
                    Usuario = "admin",
                    Contrasena = "1234",
                    Nombre = "Administrador"
                };

                await Database.InsertAsync(admin);
            }
        }

    }
}
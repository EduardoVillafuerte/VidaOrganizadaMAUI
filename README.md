📱 Vida Organizada – Aplicación .NET MAUI

ISWZ2103 – Programación IV
Facultad de Ingeniería y Ciencias Aplicadas
Ingeniería en Software

📝 Descripción del Proyecto

Vida Organizada es una aplicación multiplataforma desarrollada con .NET MAUI, que permite gestionar varios aspectos personales como:

✔ Tareas

✔ Calendario

✔ Hábitos

✔ Notas

La aplicación incluye:

Pantalla de inicio de sesión

Validación contra SQLite

Pantalla principal con navegación

Cuatro módulos funcionales

CRUD básico para cada módulo

Navegación con NavigationPage

Base de datos local creada con sqlite-net-pcl

🔐 Credenciales por defecto

La aplicación crea automáticamente un usuario la primera vez que se ejecuta:

Usuario	Contraseña	Rol
admin	1234	Administrador

Estas credenciales se almacenan localmente en SQLite y son necesarias para acceder al sistema.

🧱 Layouts utilizados

La aplicación utiliza los siguientes layouts:

LoginPage → VerticalStackLayout

MainPage → VerticalStackLayout

Módulos (Tareas, Calendario, Hábitos, Notas) → VerticalStackLayout + CollectionView

Para contenedores de elementos se usa Border (reemplazo moderno de Frame para .NET 8/9)

⚡ Eventos implementados

Cada módulo posee eventos funcionales como:

✔ Agregar registro

Ejemplo de Calendario:

private async void AgregarEvento_Clicked(object sender, EventArgs e)
{
    await App.Database.InsertAsync(new Evento { ... });
    await LoadEventos();
}

✔ Eliminar registro
private async void EliminarEvento_Clicked(object sender, EventArgs e)
{
    await App.Database.DeleteAsync(evento);
    await LoadEventos();
}

✔ Validación en Login
if (usuario == null)
    await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");

📚 Base de Datos SQLite

El archivo se genera automáticamente en:

/LocalApplicationData/vidaorganizada.db3


Tablas incluidas:

Usuarios

Tarea

Evento

Habito

Nota

Se crean al iniciar la app:

await Database.CreateTableAsync<Usuarios>();
await Database.CreateTableAsync<Tarea>();
await Database.CreateTableAsync<Evento>();
await Database.CreateTableAsync<Habito>();
await Database.CreateTableAsync<Nota>();

▶️ Funcionamiento General

El usuario abre la app.

Se muestra la pantalla de Login.

Tras iniciar sesión correctamente, se muestra la MainPage.

El usuario puede entrar a los módulos:

Tareas

Calendario

Hábitos

Notas

En cada módulo se pueden:

Agregar registros

Consultar registros

Eliminar registros

📂 Cómo ejecutar el proyecto

Clonar el repositorio:

Abrir en Visual Studio 2022 con soporte .NET MAUI.

Restaurar paquetes NuGet automáticamente.

Ejecutar en:

Windows Machine

Android Emulator

Android físico

🧑‍🤝‍🧑 Participación del Grupo

Se evidencia mediante:

Commits individuales de los integrantes

Historial del repositorio

Branches/merge visibles en GitHub

Aporte a módulos específicos

📎 Entregable de la Actividad

Este repositorio contiene:

✔ Proyecto MAUI funcional
✔ Evento implementado en cada módulo
✔ Base de datos SQLite
✔ Layouts MAUI
✔ README explicativo
✔ Historial de participación grupal

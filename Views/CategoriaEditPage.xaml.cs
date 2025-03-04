using Microsoft.Maui.Controls;
using MiAppCrud.Controllers;
using MiAppCrud.Models;

namespace MiAppCrud.Views
{
    public partial class CategoriaEditPage : ContentPage
    {
        private Categoria _categoria;

        public CategoriaEditPage(Categoria categoria = null)
        {
            InitializeComponent();
            _categoria = categoria ?? new Categoria();

            // Si la categor�a ya tiene un ID (existe), llenamos los campos
            if (_categoria.Id != 0)
            {
                NombreEntry.Text = _categoria.Nombre;
                DescripcionEntry.Text = _categoria.Descripcion;
            }
        }

        // Guardar categor�a
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescripcionEntry.Text;

            var controller = new CategoriaController();
            if (_categoria.Id == 0)
                controller.AddCategoria(_categoria);
            else
                controller.UpdateCategoria(_categoria);

            await Navigation.PopAsync();
        }

        // Nuevo m�todo para actualizar categor�a
        private async void OnUpdateClicked(object sender, EventArgs e)
        {
            _categoria.Nombre = NombreEntry.Text;
            _categoria.Descripcion = DescripcionEntry.Text;

            var controller = new CategoriaController();
            controller.UpdateCategoria(_categoria);

            await DisplayAlert("Actualizaci�n", "Categor�a actualizada exitosamente", "OK");
            await Navigation.PopAsync();
        }

        // Eliminar categor�a
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_categoria.Id != 0)
            {
                bool isConfirmed = await DisplayAlert("Confirmar Eliminaci�n", "�Est�s seguro de que deseas eliminar esta categor�a?", "S�", "No");
                if (isConfirmed)
                {
                    // Aqu� podr�as agregar la l�gica para eliminar la categor�a usando el controlador
                    var controller = new CategoriaController();
                    controller.DeleteCategoria(_categoria);

                    await Navigation.PopAsync();
                }
            }
        }
    }
}

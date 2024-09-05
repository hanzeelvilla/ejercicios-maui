using System.Collections.ObjectModel;

namespace capturaAlumnos
{   
    public partial class MainPage : ContentPage
    {   
        ObservableCollection<Alumno> alumnos = new ObservableCollection<Alumno>();  

        public MainPage()
        {
            InitializeComponent();
            listaAlumnos.ItemsSource = alumnos;
        }

        private void Agregar(object sender, EventArgs e)
        {   
            string generoSeleccionado = genero.SelectedItem.ToString();
            bool estado = activo.IsChecked;
            string municipio = null;

            if (colima.IsChecked) municipio = "Colima";
            else if (villa.IsChecked) municipio = "Villa de Álvarez";
            else if (tecoman.IsChecked) municipio = "Tecomán";
            else if (ixtlahuacan.IsChecked) municipio = "Ixtlahuacán";
            else if (coquimatlan.IsChecked) municipio = "Coquimatlán";
            else if (armeria.IsChecked) municipio = "Armería";
            else if (comala.IsChecked) municipio = "Comala";
            else if (cuauhtemoc.IsChecked) municipio = "Cuauhtémoc";
            else if (minatitlan.IsChecked) municipio = "Minatitlán";
            else if (manzanillo.IsChecked) municipio = "Manzanillo";

            alumnos.Add(new Alumno 
            { Nombre=nombre.Text, 
                Calificacion=double.Parse(calificacion.Text),
                Genero =generoSeleccionado, 
                Estado=estado,
                Municipio=municipio
            });
        }

        private async void ListaTapped(object sender, ItemTappedEventArgs e)
        {
            var alumnoSeleccionado = e.Item as Alumno;

            if (alumnoSeleccionado != null)
            {
                // Mostrar el DisplayActionSheet con opciones
                string action = await DisplayActionSheet($"Opciones para {alumnoSeleccionado.Nombre}", "Cancelar", null, "Eliminar", "Actualizar");

                if (action == "Eliminar")
                {
                    // Confirmar la eliminación
                    bool confirmacion = await DisplayAlert("Eliminar", $"¿Deseas eliminar a {alumnoSeleccionado.Nombre}?", "Sí", "No");
                    if (confirmacion)
                    {
                        // Eliminar el alumno de la lista
                        alumnos.Remove(alumnoSeleccionado);
                    }
                }
                else if (action == "Actualizar")
                {
                    // Lógica para actualizar los datos del alumno
                    nombre.Text = alumnoSeleccionado.Nombre;
                    calificacion.Text = alumnoSeleccionado.Calificacion.ToString();
                    genero.SelectedItem = alumnoSeleccionado.Genero;
                    activo.IsChecked = alumnoSeleccionado.Estado;
                    inactivo.IsChecked = !alumnoSeleccionado.Estado;

                    await DisplayAlert("Actualizar", "Modifica los datos y haz clic en 'Agregar' para guardar los cambios.", "OK");
                    alumnos.Remove(alumnoSeleccionado);
                }
            }

            // Desmarcar el elemento para que no quede seleccionado
            ((ListView)sender).SelectedItem = null;
        }
    }

    public class Alumno
    {
        public string Nombre { get; set; }
        public double Calificacion { get; set; }
        public string Genero { get; set; }
        public bool Estado { get; set; }
        public string Municipio { get; set; }
    }

}
